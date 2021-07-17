using System;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.DataAccess.Tables
{
    public class VendingMachineTableRecord: ITable
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

        public VendingMachineTableRecord(int id, string model, string manufacturer, int freq, DateTime lastMaint, string grandBalance, DateTime start, DateTime endOfLife, string state)
        {
            Id=id;
            Model=model;
            Manufacturer=manufacturer;
            Frequency=freq;
            LastMaintDate=lastMaint;
            GrandBalance = grandBalance;
            StartDate = start;
            EndOfLifeDate=endOfLife;
            State=state;
        }

        public VendingMachineTableRecord(): this(0,string.Empty, string.Empty,0,DateTime.Today, string.Empty,DateTime.Today,DateTime.Today, string.Empty)
        {

        }
    }
}