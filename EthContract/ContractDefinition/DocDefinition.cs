using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace EthContract.ContractDefinition
{


    public partial class DocDeployment : DocDeploymentBase
    {
        public DocDeployment() : base(BYTECODE) { }
        public DocDeployment(string byteCode) : base(byteCode) { }
    }

    public class DocDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b506119b4806100206000396000f3fe608060405234801561001057600080fd5b506004361061007c5760003560e01c806359d7caa81161005b57806359d7caa8146100e057806361a04be914610100578063c52bb9c714610120578063efd5e1c61461014157600080fd5b80623de2d414610081578063230a38fb146100aa5780633f036963146100bf575b600080fd5b61009461008f366004611335565b610154565b6040516100a19190611357565b60405180910390f35b6100bd6100b836600461139b565b6101c0565b005b6100d26100cd36600461152e565b6101ce565b6040519081526020016100a1565b6100f36100ee36600461139b565b6104d2565b6040516100a191906116ec565b61011361010e36600461139b565b610581565b6040516100a191906117af565b61013361012e366004611335565b6109df565b6040516100a19291906118ca565b6100bd61014f36600461139b565b610bf3565b6001600160a01b0381166000908152600160209081526040918290208054835181840281018401909452808452606093928301828280156101b457602002820191906000526020600020905b8154815260200190600101908083116101a0575b50505050509050919050565b6101cb816002610bfa565b50565b60028054600091826101df83611904565b909155506000818152602081815260409091208551805193945090928692849261020f9284929190910190611261565b5060208281015180516102289260018501920190611261565b5060408201518051610244916002840191602090910190611261565b5060608201518051610260916003840191602090910190611261565b506080820151805161027c916004840191602090910190611261565b5060a0820151600582015560c0820151600682015560e082015160078201805461010085015163ffffffff9081166401000000000267ffffffffffffffff1990921693169290921791909117905561012082015180516102e6916008840191602090910190611261565b506101408201518051610303916009840191602090910190611261565b50506040805180820190915233815260016020808301828152600a8601805493840181556000908152919091208351920180546001600160a01b031981166001600160a01b0390941693841782559151939450929183916001600160a81b03191617600160a01b83600281111561037c5761037c6116d6565b0217905550505060005b83518110156104565781600a0160405180604001604052808684815181106103b0576103b061192d565b60200260200101516001600160a01b03168152602001600060028111156103d9576103d96116d6565b9052815460018101835560009283526020928390208251910180546001600160a01b031981166001600160a01b03909316928317825593830151929390929183916001600160a81b03191617600160a01b83600281111561043c5761043c6116d6565b02179055505050808061044e90611904565b915050610386565b5060005b600a8201548110156104ca576001600083600a01838154811061047f5761047f61192d565b60009182526020808320909101546001600160a01b031683528281019390935260409091018120805460018101825590825291902001839055806104c281611904565b91505061045a565b505092915050565b600081815260208181526040808320600a01805482518185028101850190935280835260609492939192909184015b828210156105765760008481526020908190206040805180820190915290840180546001600160a01b03811683529192909190830190600160a01b900460ff166002811115610552576105526116d6565b6002811115610563576105636116d6565b8152505081526020019060010190610501565b505050509050919050565b600060205280600052604060002060009150905080600001604051806101600160405290816000820180546105b590611943565b80601f01602080910402602001604051908101604052809291908181526020018280546105e190611943565b801561062e5780601f106106035761010080835404028352916020019161062e565b820191906000526020600020905b81548152906001019060200180831161061157829003601f168201915b5050505050815260200160018201805461064790611943565b80601f016020809104026020016040519081016040528092919081815260200182805461067390611943565b80156106c05780601f10610695576101008083540402835291602001916106c0565b820191906000526020600020905b8154815290600101906020018083116106a357829003601f168201915b505050505081526020016002820180546106d990611943565b80601f016020809104026020016040519081016040528092919081815260200182805461070590611943565b80156107525780601f1061072757610100808354040283529160200191610752565b820191906000526020600020905b81548152906001019060200180831161073557829003601f168201915b5050505050815260200160038201805461076b90611943565b80601f016020809104026020016040519081016040528092919081815260200182805461079790611943565b80156107e45780601f106107b9576101008083540402835291602001916107e4565b820191906000526020600020905b8154815290600101906020018083116107c757829003601f168201915b505050505081526020016004820180546107fd90611943565b80601f016020809104026020016040519081016040528092919081815260200182805461082990611943565b80156108765780601f1061084b57610100808354040283529160200191610876565b820191906000526020600020905b81548152906001019060200180831161085957829003601f168201915b505050918352505060058201546020820152600682015460408201526007820154600381810b6060840152640100000000909104900b608082015260088201805460a0909201916108c690611943565b80601f01602080910402602001604051908101604052809291908181526020018280546108f290611943565b801561093f5780601f106109145761010080835404028352916020019161093f565b820191906000526020600020905b81548152906001019060200180831161092257829003601f168201915b5050505050815260200160098201805461095890611943565b80601f016020809104026020016040519081016040528092919081815260200182805461098490611943565b80156109d15780601f106109a6576101008083540402835291602001916109d1565b820191906000526020600020905b8154815290600101906020018083116109b457829003601f168201915b505050505081525050905081565b6109e76112e5565b6000805b6001600160a01b038416600090815260016020526040902054811015610bed5760005b6001600160a01b0385166000908152600160205260408120805482919085908110610a3b57610a3b61192d565b90600052602060002001548152602001908152602001600020600a0180549050811015610bda576001600160a01b0385166000818152600160205260408120805482919086908110610a8f57610a8f61192d565b90600052602060002001548152602001908152602001600020600a018281548110610abc57610abc61192d565b6000918252602090912001546001600160a01b0316148015610b5e575060006001600160a01b0386166000908152600160205260408120805482919086908110610b0857610b0861192d565b90600052602060002001548152602001908152602001600020600a018281548110610b3557610b3561192d565b600091825260209091200154600160a01b900460ff166002811115610b5c57610b5c6116d6565b145b8015610b6a5750601483105b15610bc8576001600160a01b0385166000908152600160205260409020805483908110610b9957610b9961192d565b9060005260206000200154848480610bb090611904565b955060148110610bc257610bc261192d565b60200201525b80610bd281611904565b915050610a0e565b5080610be581611904565b9150506109eb565b50915091565b6101cb8160015b60008281526020819052604080822081516101a081018352815461110093919291839190820190839082908290610c3090611943565b80601f0160208091040260200160405190810160405280929190818152602001828054610c5c90611943565b8015610ca95780601f10610c7e57610100808354040283529160200191610ca9565b820191906000526020600020905b815481529060010190602001808311610c8c57829003601f168201915b50505050508152602001600182018054610cc290611943565b80601f0160208091040260200160405190810160405280929190818152602001828054610cee90611943565b8015610d3b5780601f10610d1057610100808354040283529160200191610d3b565b820191906000526020600020905b815481529060010190602001808311610d1e57829003601f168201915b50505050508152602001600282018054610d5490611943565b80601f0160208091040260200160405190810160405280929190818152602001828054610d8090611943565b8015610dcd5780601f10610da257610100808354040283529160200191610dcd565b820191906000526020600020905b815481529060010190602001808311610db057829003601f168201915b50505050508152602001600382018054610de690611943565b80601f0160208091040260200160405190810160405280929190818152602001828054610e1290611943565b8015610e5f5780601f10610e3457610100808354040283529160200191610e5f565b820191906000526020600020905b815481529060010190602001808311610e4257829003601f168201915b50505050508152602001600482018054610e7890611943565b80601f0160208091040260200160405190810160405280929190818152602001828054610ea490611943565b8015610ef15780601f10610ec657610100808354040283529160200191610ef1565b820191906000526020600020905b815481529060010190602001808311610ed457829003601f168201915b505050918352505060058201546020820152600682015460408201526007820154600381810b6060840152640100000000909104900b608082015260088201805460a090920191610f4190611943565b80601f0160208091040260200160405190810160405280929190818152602001828054610f6d90611943565b8015610fba5780601f10610f8f57610100808354040283529160200191610fba565b820191906000526020600020905b815481529060010190602001808311610f9d57829003601f168201915b50505050508152602001600982018054610fd390611943565b80601f0160208091040260200160405190810160405280929190818152602001828054610fff90611943565b801561104c5780601f106110215761010080835404028352916020019161104c565b820191906000526020600020905b81548152906001019060200180831161102f57829003601f168201915b5050505050815250508152602001600a8201805480602002602001604051908101604052809291908181526020016000905b828210156110f35760008481526020908190206040805180820190915290840180546001600160a01b03811683529192909190830190600160a01b900460ff1660028111156110cf576110cf6116d6565b60028111156110e0576110e06116d6565b815250508152602001906001019061107e565b50505050815250506111f3565b905080600019148061115a57506000838152602081905260408120600a018054839081106111305761113061192d565b600091825260209091200154600160a01b900460ff166002811115611157576111576116d6565b14155b1561116457505050565b81600080858152602001908152602001600020600a01828154811061118b5761118b61192d565b6000918252602090912001805460ff60a01b1916600160a01b8360028111156111b6576111b66116d6565b02179055506040513381527fd5f03a76fc0d2f3cf1e500273ed4000e2a2784dd9161d5e6b86711c444b353d79060200160405180910390a1505050565b6000805b82602001515181101561125757336001600160a01b0316836020015182815181106112245761122461192d565b6020026020010151600001516001600160a01b031614156112455792915050565b8061124f81611904565b9150506111f7565b5060001992915050565b82805461126d90611943565b90600052602060002090601f01602090048101928261128f57600085556112d5565b82601f106112a857805160ff19168380011785556112d5565b828001600101855582156112d5579182015b828111156112d55782518255916020019190600101906112ba565b506112e1929150611304565b5090565b6040518061028001604052806014906020820280368337509192915050565b5b808211156112e15760008155600101611305565b80356001600160a01b038116811461133057600080fd5b919050565b60006020828403121561134757600080fd5b61135082611319565b9392505050565b6020808252825182820181905260009190848201906040850190845b8181101561138f57835183529284019291840191600101611373565b50909695505050505050565b6000602082840312156113ad57600080fd5b5035919050565b634e487b7160e01b600052604160045260246000fd5b604051610160810167ffffffffffffffff811182821017156113ee576113ee6113b4565b60405290565b604051601f8201601f1916810167ffffffffffffffff8111828210171561141d5761141d6113b4565b604052919050565b600082601f83011261143657600080fd5b813567ffffffffffffffff811115611450576114506113b4565b611463601f8201601f19166020016113f4565b81815284602083860101111561147857600080fd5b816020850160208301376000918101602001919091529392505050565b8035600381900b811461133057600080fd5b600082601f8301126114b857600080fd5b8135602067ffffffffffffffff8211156114d4576114d46113b4565b8160051b6114e38282016113f4565b92835284810182019282810190878511156114fd57600080fd5b83870192505b848310156115235761151483611319565b82529183019190830190611503565b979650505050505050565b6000806040838503121561154157600080fd5b823567ffffffffffffffff8082111561155957600080fd5b90840190610160828703121561156e57600080fd5b6115766113ca565b82358281111561158557600080fd5b61159188828601611425565b8252506020830135828111156115a657600080fd5b6115b288828601611425565b6020830152506040830135828111156115ca57600080fd5b6115d688828601611425565b6040830152506060830135828111156115ee57600080fd5b6115fa88828601611425565b60608301525060808301358281111561161257600080fd5b61161e88828601611425565b60808301525060a083013560a082015260c083013560c082015261164460e08401611495565b60e0820152610100611657818501611495565b90820152610120838101358381111561166f57600080fd5b61167b89828701611425565b828401525050610140808401358381111561169557600080fd5b6116a189828701611425565b8284015250508094505060208501359150808211156116bf57600080fd5b506116cc858286016114a7565b9150509250929050565b634e487b7160e01b600052602160045260246000fd5b60208082528251828201819052600091906040908185019086840185805b8381101561175457825180516001600160a01b031686528701516003811061174057634e487b7160e01b83526021600452602483fd5b85880152938501939186019160010161170a565b509298975050505050505050565b6000815180845260005b818110156117885760208185018101518683018201520161176c565b8181111561179a576000602083870101525b50601f01601f19169290920160200192915050565b60208152600082516101608060208501526117ce610180850183611762565b91506020850151601f19808685030160408701526117ec8483611762565b935060408701519150808685030160608701526118098483611762565b935060608701519150808685030160808701526118268483611762565b935060808701519150808685030160a08701526118438483611762565b935060a087015160c087015260c087015160e087015260e087015191506101006118718188018460030b9052565b87015191506101206118878782018460030b9052565b808801519250506101408187860301818801526118a48584611762565b9088015187820390920184880152935090506118c08382611762565b9695505050505050565b6102a08101818460005b60148110156118f35781518352602092830192909101906001016118d4565b505050826102808301529392505050565b600060001982141561192657634e487b7160e01b600052601160045260246000fd5b5060010190565b634e487b7160e01b600052603260045260246000fd5b600181811c9082168061195757607f821691505b6020821081141561197857634e487b7160e01b600052602260045260246000fd5b5091905056fea26469706673582212207dc34e21146d1dab2bc62023fd691cb8b3781089f743061519b4d930170ea9e764736f6c634300080b0033";
        public DocDeploymentBase() : base(BYTECODE) { }
        public DocDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CreateDocumentFunction : CreateDocumentFunctionBase { }

    [Function("CreateDocument", "uint256")]
    public class CreateDocumentFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "data", 1)]
        public virtual DocumentData Data { get; set; }
        [Parameter("address[]", "addreses", 2)]
        public virtual List<string> Addreses { get; set; }
    }

    public partial class DocumentsFunction : DocumentsFunctionBase { }

    [Function("Documents", typeof(DocumentsOutputDTO))]
    public class DocumentsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetAgentsFunction : GetAgentsFunctionBase { }

    [Function("GetAgents", typeof(GetAgentsOutputDTO))]
    public class GetAgentsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "document", 1)]
        public virtual BigInteger Document { get; set; }
    }

    public partial class GetUserDocsFunction : GetUserDocsFunctionBase { }

    [Function("GetUserDocs", "uint256[]")]
    public class GetUserDocsFunctionBase : FunctionMessage
    {
        [Parameter("address", "userAddress", 1)]
        public virtual string UserAddress { get; set; }
    }

    public partial class GetUserDocsToSignFunction : GetUserDocsToSignFunctionBase { }

    [Function("GetUserDocsToSign", typeof(GetUserDocsToSignOutputDTO))]
    public class GetUserDocsToSignFunctionBase : FunctionMessage
    {
        [Parameter("address", "userAddress", 1)]
        public virtual string UserAddress { get; set; }
    }

    public partial class RejectFunction : RejectFunctionBase { }

    [Function("Reject")]
    public class RejectFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "document", 1)]
        public virtual BigInteger Document { get; set; }
    }

    public partial class SignFunction : SignFunctionBase { }

    [Function("Sign")]
    public class SignFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "document", 1)]
        public virtual BigInteger Document { get; set; }
    }

    public partial class SignEventEventDTO : SignEventEventDTOBase { }

    [Event("SignEvent")]
    public class SignEventEventDTOBase : IEventDTO
    {
        [Parameter("address", "agent", 1, false )]
        public virtual string Agent { get; set; }
    }



    public partial class DocumentsOutputDTO : DocumentsOutputDTOBase { }

    [FunctionOutput]
    public class DocumentsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "Data", 1)]
        public virtual DocumentData Data { get; set; }
    }

    public partial class GetAgentsOutputDTO : GetAgentsOutputDTOBase { }

    [FunctionOutput]
    public class GetAgentsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "agents", 1)]
        public virtual List<Agent> Agents { get; set; }
    }

    public partial class GetUserDocsOutputDTO : GetUserDocsOutputDTOBase { }

    [FunctionOutput]
    public class GetUserDocsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[]", "documents", 1)]
        public virtual List<BigInteger> Documents { get; set; }
    }

    public partial class GetUserDocsToSignOutputDTO : GetUserDocsToSignOutputDTOBase { }

    [FunctionOutput]
    public class GetUserDocsToSignOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[20]", "documents", 1)]
        public virtual List<BigInteger> Documents { get; set; }
        [Parameter("uint256", "counter", 2)]
        public virtual BigInteger Counter { get; set; }
    }




}
