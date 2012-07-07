﻿// Copyright 2012 Peter Henell

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;
using System.Collections.ObjectModel;
using SQLDataProducer.Entities.Generators.Collections;

namespace SQLDataProducer.Entities.Generators
{
   public partial class Generator
    {
        internal static ObservableCollection<Generator> GetGUIDGenerators()
        {
            ObservableCollection<Generator> valueGenerators = new ObservableCollection<Generator>();
            valueGenerators.Add(CreateRandomGUIDGenerator());
            valueGenerators.Add(CreateQueryGenerator());
            valueGenerators.Add(StaticGUID());

            return valueGenerators;
        }

        private static Generator CreateRandomGUIDGenerator()
        {
            GeneratorParameterCollection paramss = new GeneratorParameterCollection();

            Generator gen = new Generator("Random GUID", (n, p) =>
            {
                return Wrap(Guid.NewGuid());
            }
                , paramss);
            return gen;
        }

        private static Generator StaticGUID()
        {
            GeneratorParameterCollection paramss = new GeneratorParameterCollection();

            paramss.Add(new GeneratorParameter("GUID", new Guid()));

            Generator gen = new Generator("Static GUID", (n, p) =>
            {
                string value = GetParameterByName(p, "GUID").ToString();

                return Wrap(value);
            }
                , paramss);
            return gen;
        }
    }
}