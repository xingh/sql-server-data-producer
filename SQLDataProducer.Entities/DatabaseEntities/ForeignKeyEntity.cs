﻿// Copyright 2012-2014 Peter Henell

//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at

//       http://www.apache.org/licenses/LICENSE-2.0

//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using SQLDataProducer.Entities.DatabaseEntities;
using System.Collections.ObjectModel;
using SQLDataProducer.Entities.DatabaseEntities.Collections;

namespace SQLDataProducer.Entities.DatabaseEntities
{
    public class ForeignKeyEntity : EntityBase
    {
        public ForeignKeyEntity()
        {
            Keys = new ObservableCollection<string>();
        }

        private TableEntity _referencingTable;
        [System.ComponentModel.ReadOnly(true)]
        public TableEntity ReferencingTable
        {
            get
            {
                return _referencingTable;
            }
            set
            {
                if (_referencingTable != value)
                {
                    _referencingTable = value;
                    OnPropertyChanged("ReferencingTable");
                }
            }
        }

        private string _referencingColumn;
        [System.ComponentModel.ReadOnly(true)]
        public string ReferencingColumn
        {
            get
            {
                return _referencingColumn;
            }
            set
            {
                if (_referencingColumn != value)
                {
                    _referencingColumn = value;
                    OnPropertyChanged("ReferencingColumn");
                }
            }
        }

        private ObservableCollection<string> _keys;
        [System.ComponentModel.ReadOnly(true)]
        public ObservableCollection<string> Keys
        {
            get
            {
                return _keys;
            }
            set
            {
                if (_keys != value)
                {
                    _keys = value;
                    OnPropertyChanged("Keys");
                }
            }
        }

        public ForeignKeyEntity Clone()
        {
            // TODO: Clone using the same entity as the LOAD/SAVE functionality
            ForeignKeyEntity fk = new ForeignKeyEntity();
            fk.ReferencingColumn = this.ReferencingColumn;
            fk.ReferencingTable = this.ReferencingTable;
            fk.Keys = new ObservableCollection<string>(this.Keys); ;
            return fk;
        }
    }
}
