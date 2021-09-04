using ChannelGeneration.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelGeneration.Service
{
    public class ChannelGenerationService : IChannelGenerationService
    {
        public ChannelGenerationService()
        {

        }
        public async Task<bool> ChannelGenerationJson(List<InputDataViewModel> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                //Token
                var channelJson = new ChannelViewModel();
                channelJson.Token = Guid.NewGuid().ToString();
                //Name
                channelJson.Name = input[i].TypeChannel + '-' + input[i].ProviderName;
                //FornecedorInformation
                channelJson.FornecedorInformation.Name = input[i].ProviderName;
                channelJson.FornecedorInformation.Id = -1;
                //PipelineContext
                channelJson.PipelineContext.Behavior = "Ingestão de Faturas";
                //Receiver
                channelJson.Receiver.Name = "GTIT.InvoiceProcessor.Receiver.RabbitMQFileSystem.Plugin";
                channelJson.Receiver.Version = "1.0.0.0";

                var propertyReciverOne = new Properties();
                var type = input[i].TypeChannel == "Telecom" ? "Operadora" : "Concessionaria";
                propertyReciverOne.Name = "Source";
                if (type == "Telecom")
                    propertyReciverOne.Value = $"D:\\ArquivosFacilities\\{type}\\{input[i].ProviderName}\\SourceReceiver";
                else
                    propertyReciverOne.Value = $"D:\\ArquivosFacilities\\{type}\\{input[i].TypeChannel}\\{input[i].ProviderName}\\SourceReceiver";

                var propertyReciverTwo = new Properties();
                propertyReciverTwo.Name = "Pattern";
                propertyReciverTwo.Value = "*.zip";

                var propertyReciverThree = new Properties();
                propertyReciverThree.Name = "Interval";
                Random randNum = new Random();

                propertyReciverThree.Value = randNum.Next(30, 60).ToString();

                channelJson.Receiver.Properties.Add(propertyReciverOne);
                channelJson.Receiver.Properties.Add(propertyReciverTwo);
                channelJson.Receiver.Properties.Add(propertyReciverThree);

                //Sender
                channelJson.Sender.Name = "GTIT.InvoiceProcessor.Sender.Import.Facilities.Plugin";
                channelJson.Sender.Version = "1.0.0.0";
                var propertySenderOne = new Properties();
                propertySenderOne.Name = "FailedPath";
                if (type == "Telecom")
                    propertySenderOne.Value = $"D:\\ArquivosFacilities\\{type}\\{input[i].ProviderName}\\FailedSender";
                else
                    propertySenderOne.Value = $"D:\\ArquivosFacilities\\{type}\\{input[i].TypeChannel}\\{input[i].ProviderName}\\FailedSender";

                channelJson.Sender.Properties.Add(propertySenderOne);

                //Mapper
                channelJson.Mapper.Name = "GTIT.InvoiceProcessor.Mapper.Facilities.Mapper";
                channelJson.Mapper.Version = "1.0.0.0";
                var propertyMapperOne = new Properties();
                propertyMapperOne.Name = "DocParserDocumentParserId";
                propertyMapperOne.Value = input[i].ParserId;

                var propertyMapperTwo = new Properties();
                propertyMapperTwo.Name = "FailedPath";
                if (type == "Telecom")
                    propertyMapperTwo.Value = $"D:\\ArquivosFacilities\\{type}\\{input[i].ProviderName}\\FailedMapper";
                else
                    propertyMapperTwo.Value = $"D:\\ArquivosFacilities\\{type}\\{input[i].TypeChannel}\\{input[i].ProviderName}\\FailedMapper";

                channelJson.Mapper.Properties.Add(propertyMapperOne);
                channelJson.Mapper.Properties.Add(propertyMapperTwo);


                //ReceiverEnricherSender
                channelJson.ReceiverEnricherSender.Name = "GTIT.InvoiceProcessor.Sender.FileSystem.Plugin";
                channelJson.ReceiverEnricherSender.Version = "1.0.0.0";
                var propertyReceiverEnricherSenderOne = new Properties();
                propertyReceiverEnricherSenderOne.Name = "Path";
                propertyReceiverEnricherSenderOne.Value = "D:\\ArquivosFacilities\\SourceMapper";

                channelJson.ReceiverEnricherSender.Properties.Add(propertyReceiverEnricherSenderOne);

                //MapperEnricherSender
                channelJson.MapperEnricherSender.Name = "GTIT.InvoiceProcessor.Sender.FileSystem.Plugin";
                channelJson.MapperEnricherSender.Version = "1.0.0.0";

                var propertyMapperEnricherSenderOne = new Properties();
                propertyMapperEnricherSenderOne.Name = "Path";
                propertyMapperEnricherSenderOne.Value = "D:\\ArquivosFacilities\\SourceSender";

                channelJson.MapperEnricherSender.Properties.Add(propertyMapperEnricherSenderOne);



                var myJson = JsonConvert.SerializeObject(channelJson);
                File.WriteAllText(@$"{input[i].PathFile}\\{input[i].TypeChannel}-{input[i].ProviderName}.json", myJson);


            }


            return true;
        }
    }
}
