using Orchard.Data;
using Orchard.Models.Records;

namespace Orchard.Models.Driver {
    public class StorageFilterForRecord<TRecord> : StorageFilterBase<ContentItemPartWithRecord<TRecord>> where TRecord : ContentPartRecordBase,new() {
        private readonly IRepository<TRecord> _repository;

        public StorageFilterForRecord(IRepository<TRecord> repository) {
            _repository = repository;
        }

        public bool AutomaticallyCreateMissingRecord { get; set; }

        protected override void Activated(ActivatedContentContext context, ContentItemPartWithRecord<TRecord> instance) {
            instance.Record = new TRecord();
        }

        protected override void Creating(CreateContentContext context, ContentItemPartWithRecord<TRecord> instance) {
            instance.Record.ContentItem = context.ContentItemRecord;
            _repository.Create(instance.Record);
        }

        protected override void Loading(LoadContentContext context, ContentItemPartWithRecord<TRecord> instance) {
            instance.Record = _repository.Get(instance.ContentItem.Id);
            if (instance.Record == null && AutomaticallyCreateMissingRecord) {
                instance.Record = new TRecord {ContentItem = context.ContentItemRecord};
                _repository.Create(instance.Record);
            }
        }
    }
}