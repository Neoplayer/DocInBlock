using EthContract.ContractDefinition;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;

namespace EthContract
{
    public interface IDocService
    {
        ContractHandler ContractHandler { get; }

        Task<TransactionReceipt> CreateDocumentRequestAndWaitForReceiptAsync(CreateDocumentFunction createDocumentFunction, CancellationTokenSource cancellationToken = null);
        Task<TransactionReceipt> CreateDocumentRequestAndWaitForReceiptAsync(DocumentData data, List<string> addreses, CancellationTokenSource cancellationToken = null);
        Task<string> CreateDocumentRequestAsync(CreateDocumentFunction createDocumentFunction);
        Task<string> CreateDocumentRequestAsync(DocumentData data, List<string> addreses);
        Task<DocumentsOutputDTO> DocumentsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null);
        Task<DocumentsOutputDTO> DocumentsQueryAsync(DocumentsFunction documentsFunction, BlockParameter blockParameter = null);
        Task<GetAgentsOutputDTO> GetAgentsQueryAsync(BigInteger document, BlockParameter blockParameter = null);
        Task<GetAgentsOutputDTO> GetAgentsQueryAsync(GetAgentsFunction getAgentsFunction, BlockParameter blockParameter = null);
        Task<List<BigInteger>> GetUserDocsQueryAsync(GetUserDocsFunction getUserDocsFunction, BlockParameter blockParameter = null);
        Task<List<BigInteger>> GetUserDocsQueryAsync(string userAddress, BlockParameter blockParameter = null);
        Task<GetUserDocsToSignOutputDTO> GetUserDocsToSignQueryAsync(GetUserDocsToSignFunction getUserDocsToSignFunction, BlockParameter blockParameter = null);
        Task<GetUserDocsToSignOutputDTO> GetUserDocsToSignQueryAsync(string userAddress, BlockParameter blockParameter = null);
        Task<TransactionReceipt> RejectRequestAndWaitForReceiptAsync(BigInteger document, CancellationTokenSource cancellationToken = null);
        Task<TransactionReceipt> RejectRequestAndWaitForReceiptAsync(RejectFunction rejectFunction, CancellationTokenSource cancellationToken = null);
        Task<string> RejectRequestAsync(BigInteger document);
        Task<string> RejectRequestAsync(RejectFunction rejectFunction);
        Task<TransactionReceipt> SignRequestAndWaitForReceiptAsync(BigInteger document, CancellationTokenSource cancellationToken = null);
        Task<TransactionReceipt> SignRequestAndWaitForReceiptAsync(SignFunction signFunction, CancellationTokenSource cancellationToken = null);
        Task<string> SignRequestAsync(BigInteger document);
        Task<string> SignRequestAsync(SignFunction signFunction);
    }
}