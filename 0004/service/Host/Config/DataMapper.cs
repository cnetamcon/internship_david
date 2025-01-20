using AutoMapper;
using Core.Interfaces.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace Host.Config
{
    public class DataMapper : IDataMapper
    {
        IMapper _mapper;

        public DataMapper(DataMapperConfig config)
        {
            _mapper = GetMapper(config);
        }

        private IMapper GetMapper(DataMapperConfig config)
        {
            var mapplineConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(config);
            });

            IMapper mapper = mapplineConfig.CreateMapper();

            return mapper;
        }

        public To Parse<From, To>(From model)
        {
            return _mapper.Map<From, To>(model);
        }
        public IEnumerable<To> Parse<From, To>(IEnumerable<From> models)
        {
            return models.Select(Parse<From, To>).ToList();
        }
    }
}