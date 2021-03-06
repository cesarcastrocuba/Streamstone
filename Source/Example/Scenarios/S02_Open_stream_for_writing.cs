﻿using System;
using System.Linq;

using Streamstone;

namespace Example.Scenarios
{
    public class S02_Open_stream_for_writing : Scenario
    {
        public override void Run()
        {
            OpenNonExistingStream();
            OpenExistingStream();
        }

        void OpenNonExistingStream()
        {
            try
            {
                Stream.Open(Partition);
            }
            catch (StreamNotFoundException)
            {
                Console.WriteLine("Opening non-existing stream will throw StreamNotFoundException");
            }
        }

        void OpenExistingStream()
        {
            Stream.Provision(Partition);

            var stream = Stream.Open(Partition);

            Console.WriteLine("Opened existing (empty) stream in partition '{0}'", stream.Partition);
            Console.WriteLine("Etag: {0}", stream.ETag);
            Console.WriteLine("Version: {0}", stream.Version);
        }
    }
}
