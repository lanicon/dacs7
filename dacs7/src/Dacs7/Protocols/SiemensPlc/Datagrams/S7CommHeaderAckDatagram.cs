﻿// Copyright (c) insite-gmbh. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License in the project root for license information.

namespace Dacs7.Protocols.SiemensPlc
{

    public class S7CommHeaderAckDatagram
    {
        public byte ErrorClass { get; set; }

        public byte ErrorCode { get; set; }
    }
}
