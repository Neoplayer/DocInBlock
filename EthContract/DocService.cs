using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using EthContract.ContractDefinition;
using Nethereum.UI;

namespace EthContract
{
    public partial class DocService : IDocService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, DocDeployment docDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<DocDeployment>().SendRequestAndWaitForReceiptAsync(docDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, DocDeployment docDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<DocDeployment>().SendRequestAsync(docDeployment);
        }

        public static async Task<DocService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, DocDeployment docDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, docDeployment, cancellationTokenSource);
            return new DocService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3 { get; }

        public ContractHandler ContractHandler { get; }


        

        public DocService(IEthereumHostProvider hostProvider)
        {
            Web3 = hostProvider.GetWeb3Async().Result;
            ContractHandler = Web3.Eth.GetContractHandler("0x4cd497cfb6a57a91a2e370a9a49b575dc272a9e7");
        }

        public DocService(IWeb3 web3)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler("0x4cd497cfb6a57a91a2e370a9a49b575dc272a9e7");
        }

        public DocService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CreateDocumentRequestAsync(CreateDocumentFunction createDocumentFunction)
        {
             return ContractHandler.SendRequestAsync(createDocumentFunction);
        }

        public Task<TransactionReceipt> CreateDocumentRequestAndWaitForReceiptAsync(CreateDocumentFunction createDocumentFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createDocumentFunction, cancellationToken);
        }

        public Task<string> CreateDocumentRequestAsync(DocumentData data, List<string> addreses)
        {
            var createDocumentFunction = new CreateDocumentFunction();
                createDocumentFunction.Data = data;
                createDocumentFunction.Addreses = addreses;
            
             return ContractHandler.SendRequestAsync(createDocumentFunction);
        }

        public Task<TransactionReceipt> CreateDocumentRequestAndWaitForReceiptAsync(DocumentData data, List<string> addreses, CancellationTokenSource cancellationToken = null)
        {
            var createDocumentFunction = new CreateDocumentFunction();
                createDocumentFunction.Data = data;
                createDocumentFunction.Addreses = addreses;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createDocumentFunction, cancellationToken);
        }

        public Task<DocumentsOutputDTO> DocumentsQueryAsync(DocumentsFunction documentsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<DocumentsFunction, DocumentsOutputDTO>(documentsFunction, blockParameter);
        }

        public Task<DocumentsOutputDTO> DocumentsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var documentsFunction = new DocumentsFunction();
                documentsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<DocumentsFunction, DocumentsOutputDTO>(documentsFunction, blockParameter);
        }

        public Task<GetAgentsOutputDTO> GetAgentsQueryAsync(GetAgentsFunction getAgentsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAgentsFunction, GetAgentsOutputDTO>(getAgentsFunction, blockParameter);
        }

        public Task<GetAgentsOutputDTO> GetAgentsQueryAsync(BigInteger document, BlockParameter blockParameter = null)
        {
            var getAgentsFunction = new GetAgentsFunction();
                getAgentsFunction.Document = document;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetAgentsFunction, GetAgentsOutputDTO>(getAgentsFunction, blockParameter);
        }

        public Task<List<BigInteger>> GetUserDocsQueryAsync(GetUserDocsFunction getUserDocsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetUserDocsFunction, List<BigInteger>>(getUserDocsFunction, blockParameter);
        }

        
        public Task<List<BigInteger>> GetUserDocsQueryAsync(string userAddress, BlockParameter blockParameter = null)
        {
            var getUserDocsFunction = new GetUserDocsFunction();
                getUserDocsFunction.UserAddress = userAddress;
            
            return ContractHandler.QueryAsync<GetUserDocsFunction, List<BigInteger>>(getUserDocsFunction, blockParameter);
        }

        public Task<GetUserDocsToSignOutputDTO> GetUserDocsToSignQueryAsync(GetUserDocsToSignFunction getUserDocsToSignFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetUserDocsToSignFunction, GetUserDocsToSignOutputDTO>(getUserDocsToSignFunction, blockParameter);
        }

        public Task<GetUserDocsToSignOutputDTO> GetUserDocsToSignQueryAsync(string userAddress, BlockParameter blockParameter = null)
        {
            var getUserDocsToSignFunction = new GetUserDocsToSignFunction();
                getUserDocsToSignFunction.UserAddress = userAddress;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetUserDocsToSignFunction, GetUserDocsToSignOutputDTO>(getUserDocsToSignFunction, blockParameter);
        }

        public Task<string> RejectRequestAsync(RejectFunction rejectFunction)
        {
             return ContractHandler.SendRequestAsync(rejectFunction);
        }

        public Task<TransactionReceipt> RejectRequestAndWaitForReceiptAsync(RejectFunction rejectFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rejectFunction, cancellationToken);
        }

        public Task<string> RejectRequestAsync(BigInteger document)
        {
            var rejectFunction = new RejectFunction();
                rejectFunction.Document = document;
            
             return ContractHandler.SendRequestAsync(rejectFunction);
        }

        public Task<TransactionReceipt> RejectRequestAndWaitForReceiptAsync(BigInteger document, CancellationTokenSource cancellationToken = null)
        {
            var rejectFunction = new RejectFunction();
                rejectFunction.Document = document;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rejectFunction, cancellationToken);
        }

        public Task<string> SignRequestAsync(SignFunction signFunction)
        {
             return ContractHandler.SendRequestAsync(signFunction);
        }

        public Task<TransactionReceipt> SignRequestAndWaitForReceiptAsync(SignFunction signFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(signFunction, cancellationToken);
        }

        public Task<string> SignRequestAsync(BigInteger document)
        {
            var signFunction = new SignFunction();
                signFunction.Document = document;
            
             return ContractHandler.SendRequestAsync(signFunction);
        }

        public Task<TransactionReceipt> SignRequestAndWaitForReceiptAsync(BigInteger document, CancellationTokenSource cancellationToken = null)
        {
            var signFunction = new SignFunction();
                signFunction.Document = document;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(signFunction, cancellationToken);
        }
    }
}
