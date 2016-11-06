﻿using System;
using ArduinoUploader.Hardware;

namespace ArduinoUploader.Protocols.STK500v1.Messages
{
    internal class ExecuteProgramPageRequest : Request
    {
        public ExecuteProgramPageRequest(MemoryType memType, byte[] bytesToCopy)
        {
            var size = bytesToCopy.Length;
            Bytes = new byte[size + 5];
            var i = 0;
            Bytes[i++] = Constants.CMD_STK_PROG_PAGE;
            Bytes[i++] = (byte)((size >> 8) & 0xff);
            Bytes[i++] = (byte)(size & 0xff);
            Bytes[i++] = (byte) (memType == MemoryType.EEPROM ? 'E' : 'F');
            Buffer.BlockCopy(bytesToCopy, 0, Bytes, i, size);
            i += size;
            Bytes[i] = Constants.SYNC_CRC_EOP;
        }
    }
}
