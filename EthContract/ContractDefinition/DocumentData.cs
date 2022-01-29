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
        public virtual string Name { get; set; } = String.Empty;

        [Required]
        [Parameter("string", "Type", 2)]
        public virtual string Type { get; set; } = String.Empty;

        [Parameter("string", "Format", 3)]
        public virtual string Format { get; set; } = String.Empty;

        [Parameter("string", "Country", 4)]
        public virtual string Country { get; set; } = String.Empty;

        [Parameter("string", "City", 5)]
        public virtual string City { get; set; } = String.Empty;

        [Required]
        [Parameter("uint256", "DateStart", 6)]
        public virtual BigInteger DateStart { get; set; } = DateTime.Now.Ticks;

        [Required]
        [Parameter("uint256", "DateEnd", 7)]
        public virtual BigInteger DateEnd { get; set; } = DateTime.Now.AddDays(10).Ticks;

        [Parameter("int32", "Days", 8)]
        public virtual int Days { get; set; }

        [Parameter("int32", "Hours", 9)]
        public virtual int Hours { get; set; }

        [Required]
        [Parameter("string", "EventOrganizer", 10)]
        public virtual string EventOrganizer { get; set; } = String.Empty;

        [Parameter("string", "Notes", 11)]
        public virtual string Notes { get; set; } = String.Empty;

        [Required]
        public string Region
        {
            get
            {
                var countryRegion = RegionsManager.Regions.FirstOrDefault(x => x.Label == Country);
                var cityRegion = countryRegion?.Childs?.FirstOrDefault(x => x.Label == City);

                return countryRegion?.Id.ToString() ?? "0" + cityRegion?.Id.ToString() ?? "0";
            }
            set
            {
                var country = RegionsManager.Regions.FirstOrDefault(x => x.Id.ToString() == value[0].ToString());
                Country = country?.Label ?? String.Empty;
                City = country?.Childs?.FirstOrDefault(x => x.Id.ToString() == value[1].ToString())?.Label ?? String.Empty;
            }
        }


        public DateTime?[] RangeDates
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
