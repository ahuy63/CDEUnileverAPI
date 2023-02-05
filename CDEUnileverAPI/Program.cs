using CDEUnileverAPI.Core.IConfiguration;
using CDEUnileverAPI.Core.IServices;
using CDEUnileverAPI.Core.Services;
using CDEUnileverAPI.Data;
using CDEUnileverAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CDEUnileverDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CDEUnilever")));

//JWT
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(jwt =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false
        };
    });

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

///
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IAreaService), typeof(AreaService));
builder.Services.AddTransient(typeof(ITitleService), typeof(TitleService));
builder.Services.AddTransient(typeof(IDistributorService), typeof(DistributorService));
builder.Services.AddTransient(typeof(IUserService), typeof(UserService));
builder.Services.AddTransient(typeof(IQuestionnaireDetailService), typeof(QuestionnaireDetailService));
builder.Services.AddTransient(typeof(IQuestionnaireService), typeof(QuestionnaireService));
builder.Services.AddTransient(typeof(IVisitPlanService), typeof(VisitPlanService));
builder.Services.AddTransient(typeof(IJobTaskService), typeof(JobTaskService));
builder.Services.AddTransient(typeof(ICommentService), typeof(CommentService));
builder.Services.AddTransient(typeof(INotiService), typeof(NotiService));
builder.Services.AddTransient(typeof(ISurveyService), typeof(SurveyService));
builder.Services.AddTransient(typeof(IParticipantService), typeof(ParticipantService));
builder.Services.AddTransient(typeof(ISurveyAnswerService), typeof(SurveyAnswerService));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<CDEUnileverDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
