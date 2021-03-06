﻿// Copyright (c) insite-gmbh. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License in the project root for license information.

using System;

namespace Dacs7.Protocols.SiemensPlc
{
    internal class S7CommSetupAckDataDatagram
    {
        public S7AckDataDatagram Header { get; set; } = new S7AckDataDatagram();

        public S7CommSetupParameterDatagram Parameter { get; set; } = new S7CommSetupParameterDatagram();


        public static Memory<byte> TranslateToMemory(S7CommSetupAckDataDatagram datagram)
        {
            var result = S7AckDataDatagram.TranslateToMemory(datagram.Header);
            S7CommSetupParameterDatagram.TranslateToMemory(datagram.Parameter, result.Slice(datagram.Header.GetParameterOffset()));
            return result;
        }

        public static S7CommSetupAckDataDatagram TranslateFromMemory(Memory<byte> data)
        {
            var span = data.Span;
            var result = new S7CommSetupAckDataDatagram
            {
                Header = S7AckDataDatagram.TranslateFromMemory(data),
            };
            result.Parameter = S7CommSetupParameterDatagram.TranslateFromMemory(data.Slice(result.Header.GetParameterOffset()));
            return result;
        }
    }
}
