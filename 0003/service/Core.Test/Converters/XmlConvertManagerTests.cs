﻿using Core.Interfaces.Converters;
using NUnit.Framework;

namespace Core.Test.Converters
{
    public class XmlConvertManagerTests : BaseTest
    {
        private ConvertTestModel _model;
        private IXmlConvertManager _converter;

        [SetUp]
        public void Setup()
        {

            _converter = GetService<IXmlConvertManager>();
            _model = new ConvertTestModel().GetBaseModel();
        }

        [Test]
        public void DeserializeTest()
        {
            Assert.AreEqual(_model.IntValue, 2_147_000_000);
            Assert.NotNull(_converter);
            var model = _converter.Deserialize<ConvertTestModel>(_model.GetBaseXml());

            Assert.AreEqual(_model.DT, model.DT);
            Assert.AreEqual(_model.Time, model.Time);
            Assert.AreEqual(_model.Title, model.Title);
            Assert.AreEqual(_model.BoolValue, model.BoolValue);
            Assert.AreEqual(_model.IntValue, model.IntValue);
            Assert.AreEqual(_model.Path, model.Path);
            Assert.AreEqual(_model.State, model.State);
        }

        [Test]
        public void SerializeTest()
        {
            var xml = _converter.Serialize(_model);
            Assert.AreEqual(xml, _model.GetBaseXml());
        }
    }
}