﻿namespace CDEUnileverAPI.Models
{
    public class Area_User
    {
        public int Id { get; set; }
        public int Id_Area { get; set; }
        public Area Area { get; set; }
        public int Id_User { get; set; }
        public User User { get; set; }
    }
}
