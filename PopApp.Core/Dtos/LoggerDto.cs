﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PopApp.Core.Dtos
{
    public class LoggerDto
    {
        public int LoggerId { get; set; }
        public string Screen { get; set; }
        public string UserName { get; set; }
        public string Process { get; set; }
        public DateTime LoggerDate { get; set; }
    }
}
