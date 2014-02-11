﻿using System.Collections.Generic;
using HangFire.Server;

namespace HangFire.Storage
{
    public abstract class JobStorage
    {
        private static JobStorage _current;

        public static void SetCurrent(JobStorage storage)
        {
            _current = storage;
        }

        public static JobStorage Current { get { return _current; } }

        public abstract IStorageConnection CreateConnection();
        public abstract IStorageConnection CreatePooledConnection();

        public abstract IJobFetcher CreateFetcher(
            IEnumerable<string> queues, int workersCount);

        public abstract IEnumerable<IThreadWrappable> GetComponents();
    }
}
