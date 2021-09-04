using ChannelGeneration.Service;
using ChannelGeneration.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChannelGeneration.Controllers
{
    public class ChannelGenerationController : Controller
    {
        private readonly IChannelGenerationService _channelGenerationService;
        public ChannelGenerationController(IChannelGenerationService channelGenerationService)
        {
            _channelGenerationService = channelGenerationService;
        }

        [HttpPost("api/generation-channel")]
        public async Task<ActionResult> GenerationChannel([FromBody] List<InputDataViewModel> input)
        {
            await _channelGenerationService.ChannelGenerationJson(input);
            return Ok();
        }
    }
}
