﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 教务系统.辅助项
{
    internal class TrainingPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public string number { get; set; }
        public string Yes { get; set; }

        public TrainingPlan()
        {

        }
        public TrainingPlan(int id, string Monday, string Tuesday, string Wednesday,
            string Thursday, string Friday, string Saturday, string Sunday, string number, string Yes)
        {
            this.Id = id;
            this.Saturday = Saturday;
            this.Monday = Monday;
            this.Tuesday = Tuesday;
            this.Wednesday = Wednesday;
            this.Sunday = Sunday;
            this.Thursday = Thursday;
            this.Friday = Friday;
            this.number = number;
            this.Yes = Yes;
        }
    }
}
