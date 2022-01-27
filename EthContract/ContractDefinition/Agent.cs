using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace EthContract.ContractDefinition
{
    public partial class Agent : AgentBase { }

    public class AgentBase 
    {
        [Parameter("address", "Address", 1)]
        public virtual string Address { get; set; }
        [Parameter("uint8", "Status", 2)]
        public virtual byte Status { get; set; }
    }
}
