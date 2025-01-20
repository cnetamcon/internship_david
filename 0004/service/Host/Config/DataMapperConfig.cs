using AM.Srt.Models;
using AM.Stl.Models;
using AutoMapper;
using Core.Extensions;
using Core.Settings.Interfaces;
using Core.Settings.Models;
using System.Collections.Generic;
using System.Linq;

namespace Host.Config
{
    public class DataMapperConfig : Profile
    {
        private readonly ISubtitleColorSettingsManager _colorSettingsManager;
        private readonly ISrtEncodingSettingsManager _encodingSettingsManager;

        private readonly Dictionary<byte[], byte[]> _replaceDictionary;
        private readonly SubtitleColorAModel _subtitleColorAModel;

        public DataMapperConfig(ISubtitleColorSettingsManager colorSettingsManager,
            ISrtEncodingSettingsManager encodingSettingsManager)
        {
            _colorSettingsManager = colorSettingsManager;
            _encodingSettingsManager = encodingSettingsManager;

            _replaceDictionary = GetReplaceDictionary(encodingSettingsManager.Get());
            _subtitleColorAModel = _colorSettingsManager.Get();

            RegisterApiModels();
        }

        private void RegisterApiModels()
        {
            CreateMap<SrtSubtitlesAModel, StlSubtitleAModel>();
            // Uncomment after model implement
            // CreateMap<SrtSubtitleLineAModel, StlSubtitleLineAModel>();
            //     .ForMember(x => x.Color, xc => xc.MapFrom(c => ConvertColorSrtToStl(c.Color)))
            //     .ForMember(x => x.Text, xc => xc.MapFrom(c => ConvertTextSrtToStl(c.Text)));
        }

        private Dictionary<byte[], byte[]> GetReplaceDictionary(SrtEncodingAModel srtEncodingAModel)
        {
            Dictionary<byte[], byte[]> result = new Dictionary<byte[], byte[]>();

            foreach (var pair in srtEncodingAModel.Pairs)
            {
                result.Add(pair.From, pair.To);
            }

            return result;
        }

        private byte[] ConvertTextSrtToStl(byte[] text)
        {
            return text.ReplacePairs(_replaceDictionary);
        }

        private byte ConvertColorSrtToStl(string color)
        {
            return _subtitleColorAModel.Pairs
                .FirstOrDefault(x => x.ColorSrt == color)
                ?.ColorStl
                    ?? 0x00;
        }
    }
}
