using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelGeneration.ViewModel
{
    public class ChannelViewModel
    {
        public string Token { get; set; }
        public string Name { get; set; }
   
        public FornecedorInformationViewModel FornecedorInformation { get; set; }
        public PipelineContext PipelineContext { get; set; }
        public Receiver Receiver { get; set; }
        public Sender Sender { get; set; }
        public Mapper Mapper { get; set; }
        public ReceiverEnricherSender ReceiverEnricherSender { get; set; }
        public MapperEnricherSender MapperEnricherSender { get; set; }
        public ChannelViewModel()
        {
            this.FornecedorInformation = new FornecedorInformationViewModel();
            this.PipelineContext = new PipelineContext();
            this.Receiver = new Receiver();
            this.Sender = new Sender();
            this.Mapper = new Mapper();
            this.ReceiverEnricherSender = new ReceiverEnricherSender();
            this.MapperEnricherSender = new MapperEnricherSender();

        }
    }
   
    public class PipelineContext
    {
        public string Behavior { get; set; }
    }
    public class Receiver
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<Properties> Properties { get; set; }
        public Receiver()
        {
            this.Properties = new List<Properties>();
        }

    }
    public class Properties
    {
        public string Name { get; set;}
        public string Value { get; set; }

    }
    public class Sender
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<Properties> Properties { get; set; }
        public Sender()
        {
            this.Properties = new List<Properties>();
        }

    }
    public class Mapper
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<Properties> Properties { get; set; }
        public Mapper()
        {
            this.Properties = new List<Properties>();
        }

    }
    public class ReceiverEnricherSender
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<Properties> Properties { get; set; }
        public ReceiverEnricherSender()
        {
            this.Properties = new List<Properties>();
        }

    }
    public class MapperEnricherSender
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public List<Properties> Properties { get; set; }
        public MapperEnricherSender()
        {
            this.Properties = new List<Properties>();
        }

    }
}
