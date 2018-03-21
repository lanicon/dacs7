﻿// Copyright (c) insite-gmbh. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License in the project root for license information.

namespace Dacs7.Protocols.SiemensPlc
{
    public class WriteItemSpecification : ReadItemSpecification
    {
        public byte[] Data { get; set; }


        public override WriteItemSpecification Clone()
        {
            var clone = base.Clone();
            clone.Data = Data;
            return clone;
        }

        public WriteItemSpecification Clone(byte[] data)
        {
            var clone = base.Clone();
            clone.Data = data;
            return clone;
        }
    }
}
