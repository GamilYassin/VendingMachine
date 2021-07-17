﻿using System;

namespace VendingMachine.DataAccess.Tables
{
    public class VendingMachineRecord
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Frequency { get; set; }
        public DateTime LastMaintDate { get; set; }
        public string GrandBalance { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndOfLifeDate { get; set; }
        public string State { get; set; }
    }
}