﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsbRelayNet.RelayLib;

namespace WorkAttendanceEvidence
{
    public class RelayItem
    {
        private readonly RelayInfo _relayInfo;

        public RelayItem(RelayInfo relayInfo)
        {
            this._relayInfo = relayInfo;
        }

        public RelayInfo RelayInfo
        {
            get
            {
                return this._relayInfo;
            }
        }


        public override string ToString()
        {
            return string.Format(
                "#{0}  @ '{1}'",
                this._relayInfo.Id,
                this._relayInfo.HidInfo.Path);
        }
    }
}
