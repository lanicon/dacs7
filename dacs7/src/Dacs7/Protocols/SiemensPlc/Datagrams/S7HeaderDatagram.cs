﻿// Copyright (c) insite-gmbh. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License in the project root for license information.

using System;
using System.Buffers.Binary;

namespace Dacs7.Protocols.SiemensPlc
{

    internal class S7HeaderDatagram
    {

        public byte ProtocolId { get; set; } = 0x32;

        public byte PduType { get; set; }

        public UInt16 RedundancyIdentification { get; set; } = UInt16.MaxValue;

        public UInt16 ProtocolDataUnitReference { get; set; } = UInt16.MaxValue;

        public UInt16 ParamLength { get; set; }

        public UInt16 DataLength { get; set; }



        public int GetMemorySize()
        {
            return GetHeaderSize() + ParamLength + DataLength;
        }

        public int GetHeaderSize()
        {
            return 10;
        }


        public static Memory<byte> TranslateToMemory(S7HeaderDatagram datagram)
        {
            var length = datagram.GetMemorySize();
            var result = new Memory<byte>(new byte[length]);  // check if we could use ArrayBuffer
            var span = result.Span;

            span[0] = datagram.ProtocolId;
            span[1] = datagram.PduType;
            BinaryPrimitives.WriteUInt16BigEndian(span.Slice(2, 2), datagram.RedundancyIdentification);
            BinaryPrimitives.WriteUInt16BigEndian(span.Slice(4, 2), datagram.ProtocolDataUnitReference);
            BinaryPrimitives.WriteUInt16BigEndian(span.Slice(6, 2), datagram.ParamLength);
            BinaryPrimitives.WriteUInt16BigEndian(span.Slice(8, 2), datagram.DataLength);

            return result;
        }

        public static S7HeaderDatagram TranslateFromMemory(Memory<byte> data)
        {
            var span = data.Span;
            var result = new S7HeaderDatagram
            {
                ProtocolId = span[0],
                PduType = span[1],
                RedundancyIdentification = BinaryPrimitives.ReadUInt16BigEndian(span.Slice(2, 2)),
                ProtocolDataUnitReference = BinaryPrimitives.ReadUInt16BigEndian(span.Slice(4, 2)),
                ParamLength = BinaryPrimitives.ReadUInt16BigEndian(span.Slice(6, 2)),
                DataLength = BinaryPrimitives.ReadUInt16BigEndian(span.Slice(8, 2)),
            };

            return result;
        }
    }
}
