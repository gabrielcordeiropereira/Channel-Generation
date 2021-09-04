using ChannelGeneration.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelGeneration.Service
{
    public interface IChannelGenerationService
    {
        Task<bool> ChannelGenerationJson(List<InputDataViewModel> input);
    }
}
