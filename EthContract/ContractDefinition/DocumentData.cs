using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EthContract.ContractDefinition
{
    public partial class DocumentData : DocumentDataBase { }

    public class DocumentDataBase
    {
        [Required]
        [Parameter("string", "Name", 1)]
        public virtual string Name { get; set; }
        [Required]
        [Parameter("string", "Type", 2)]
        public virtual string Type { get; set; }
        [Required]
        [Parameter("string", "Format", 3)]
        public virtual string Format { get; set; }
        [Parameter("string", "Country", 4)]
        public virtual string Country { get; set; }
        [Parameter("string", "City", 5)]
        public virtual string City { get; set; }
        [Parameter("uint256", "DateStart", 6)]
        public virtual BigInteger DateStart { get; set; }
        [Parameter("uint256", "DateEnd", 7)]
        public virtual BigInteger DateEnd { get; set; }
        [Parameter("int16", "Days", 8)]
        public virtual short Days { get; set; }
        [Parameter("int16", "Hours", 9)]
        public virtual short Hours { get; set; }
        [Parameter("string", "EventOrganizer", 10)]
        public virtual string EventOrganizer { get; set; }
        [Parameter("string", "Notes", 11)]
        public virtual string Notes { get; set; }


        public DateTime?[] RangePicker 
        {
            get
            {
                return new DateTime?[] { new DateTime((long)DateStart), new DateTime((long)DateEnd) };
            }
            set
            {
                DateStart = value[0].Value.Ticks;
                DateEnd = value[1].Value.Ticks;
            } 
        }
    }
}
