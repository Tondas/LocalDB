using System;

namespace LocalDB.Utils.Exceptions
{
    public class LocalDbException : Exception
    {
        #region Constants + Fields + Properties


        #endregion

        // Ctors

        public LocalDbException(string message)
            : base(message)
        {
        }

        public LocalDbException(string message, params object[] args)
            : base(string.Format(message, args))
        {
        }

        // Static Methods

        public static LocalDbException FileNotFound(string file)
        {
            return new LocalDbException("File '{0}' not found.", file);
        }


        // Methods
        /*
        internal static LocalDbException FileNotFound(string fileId)
        {
            return new LocalDbException(FILE_NOT_FOUND, "File '{0}' not found.", fileId);
        }

        internal static LocalDbException DatabaseShutdown()
        {
            return new LocalDbException(DATABASE_SHUTDOWN, "Database is in shutdown process.");
        }

        internal static LocalDbException InvalidDatabase()
        {
            return new LocalDbException(INVALID_DATABASE, "Datafile is not a LiteDB database.");
        }

        internal static LocalDbException InvalidDatabaseVersion(int version)
        {
            return new LocalDbException(INVALID_DATABASE_VERSION, "Invalid database version: {0}", version);
        }

        internal static LocalDbException FileSizeExceeded(long limit)
        {
            return new LocalDbException(FILE_SIZE_EXCEEDED, "Database size exceeds limit of {0}.", StorageUnitHelper.FormatFileSize(limit));
        }

        internal static LocalDbException CollectionLimitExceeded(int limit)
        {
            return new LocalDbException(COLLECTION_LIMIT_EXCEEDED, "This database exceeded the maximum limit of collection names size: {0} bytes", limit);
        }

        internal static LocalDbException IndexNameLimitExceeded(int limit)
        {
            return new LocalDbException(INDEX_NAME_LIMIT_EXCEEDED, "This collection exceeded the maximum limit of indexes names/expression size: {0} bytes", limit);
        }

        internal static LocalDbException InvalidIndexName(string name, string collection, string reason)
        {
            return new LocalDbException(INVALID_INDEX_NAME, "Invalid index name '{0}' on collection '{1}': {2}", name, collection, reason);
        }

        internal static LocalDbException InvalidCollectionName(string name, string reason)
        {
            return new LocalDbException(INVALID_COLLECTION_NAME, "Invalid collection name '{0}': {1}", name, reason);
        }

        internal static LocalDbException IndexDropId()
        {
            return new LocalDbException(INDEX_DROP_ID, "Primary key index '_id' can't be dropped.");
        }

        internal static LocalDbException TempEngineAlreadyDefined()
        {
            return new LocalDbException(TEMP_ENGINE_ALREADY_DEFINED, "Temporary engine already defined or auto created.");
        }

        internal static LocalDbException CollectionNotFound(string key)
        {
            return new LocalDbException(COLLECTION_NOT_FOUND, "Collection not found: '{0}'", key);
        }

        internal static LocalDbException InvalidExpressionType(BsonExpression path, BsonExpressionType type)
        {
            return new LocalDbException(INVALID_EXPRESSION_TYPE, "Expression '{0}' must be a {1} type.", path.Source, type);
        }

        internal static LocalDbException InvalidExpressionTypeConditional(BsonExpression path)
        {
            return new LocalDbException(INVALID_EXPRESSION_TYPE, "Expression '{0}' are not supported as conditional clause.", path.Source);
        }

        internal static LocalDbException CollectionAlreadyExist(string key)
        {
            return new LocalDbException(COLLECTION_ALREADY_EXIST, "Collection already exist: '{0}'", key);
        }

        internal static LocalDbException IndexAlreadyExist(string name)
        {
            return new LocalDbException(INDEX_ALREADY_EXIST, "Index name '{0}' already exist with a differnt expression. Try drop index first.", name);
        }

        internal static LocalDbException InvalidUpdateField(string field)
        {
            return new LiteException(INVALID_UPDATE_FIELD, "'{0}' can't be modified in UPDATE command.", field);
        }

        internal static LiteException IndexLimitExceeded(string collection)
        {
            return new LiteException(INDEX_LIMIT_EXCEEDED, "Collection '{0}' exceeded the maximum limit of indices: {1}", collection, INDEX_PER_COLLECTION);
        }

        internal static LiteException IndexDuplicateKey(string field, BsonValue key)
        {
            return new LiteException(INDEX_DUPLICATE_KEY, "Cannot insert duplicate key in unique index '{0}'. The duplicate value is '{1}'.", field, key);
        }

        internal static LiteException IndexKeyTooLong()
        {
            return new LiteException(INDEX_KEY_TOO_LONG, "Index key must be less than {0} bytes.", IndexService.MAX_INDEX_LENGTH);
        }

        internal static LiteException IndexNotFound(string collection, string name)
        {
            return new LiteException(INDEX_NOT_FOUND, "Index not found on '{0}.{1}'.", collection, name);
        }

        internal static LiteException LockTimeout(string mode, TimeSpan ts)
        {
            return new LiteException(LOCK_TIMEOUT, "Database lock timeout when entering in {0} mode after {1}", mode, ts.ToString());
        }

        internal static LiteException LockTimeout(string mode, string collection, TimeSpan ts)
        {
            return new LiteException(LOCK_TIMEOUT, "Collection '{0}' lock timeout when entering in {1} mode after {2}", collection, mode, ts.ToString());
        }

        internal static LiteException InvalidCommand(string command)
        {
            return new LiteException(INVALID_COMMAND, "Command '{0}' is not a valid shell command.", command);
        }

        internal static LiteException AlreadyExistsCollectionName(string newName)
        {
            return new LiteException(ALREADY_EXISTS_COLLECTION_NAME, "New collection name '{0}' already exists.", newName);
        }

        internal static LiteException AlreadyOpenDatafile(string filename)
        {
            return new LiteException(ALREADY_OPEN_DATAFILE, "Your datafile '{0}' is open in another process.", filename);
        }

        internal static LiteException DatabaseWrongPassword()
        {
            return new LiteException(DATABASE_WRONG_PASSWORD, "Invalid database password.");
        }

        internal static LiteException ReadOnlyDatabase()
        {
            return new LiteException(READ_ONLY_DATABASE, "This action are not supported because database was opened in read only mode.");
        }

        internal static LiteException InvalidDbRef(string path)
        {
            return new LiteException(INVALID_DBREF, "Invalid value for DbRef in path '{0}'. Value must be document like {{ $ref: \"?\", $id: ? }}", path);
        }

        internal static LiteException InvalidTransactionState(string method, TransactionState state)
        {
            return new LiteException(INVALID_TRANSACTION_STATE, "'{0}' are not supported because transaction are in {1} state", method, state);
        }

        internal static LiteException AlreadyExistsTransaction()
        {
            return new LiteException(INVALID_TRANSACTION_STATE, "The current thread already contains an open transaction. Use the Commit/Rollback method to release the previous transaction.");
        }

        internal static LiteException MissingTransaction(string method)
        {
            return new LiteException(INVALID_TRANSACTION_STATE, "'{0}' are not supported because there is no open transaction in current thread.", method);
        }

        internal static LiteException CollectionLockerNotFound(string collection)
        {
            return new LiteException(INVALID_TRANSACTION_STATE, "Collection locker '{0}' was not found inside dictionary.", collection);
        }

        internal static LiteException InvalidFormat(string field)
        {
            return new LiteException(INVALID_FORMAT, "Invalid format: {0}", field);
        }

        internal static LiteException DocumentMaxDepth(int depth, Type type)
        {
            return new LiteException(DOCUMENT_MAX_DEPTH, "Document has more than {0} nested documents in '{1}'. Check for circular references (use DbRef).", depth, type == null ? "-" : type.Name);
        }

        internal static LiteException InvalidCtor(Type type, Exception inner)
        {
            return new LiteException(INVALID_CTOR, inner, "Failed to create instance for type '{0}' from assembly '{1}'. Checks if the class has a public constructor with no parameters.", type.FullName, type.AssemblyQualifiedName);
        }

        internal static LiteException UnexpectedToken(Token token, string expected = null)
        {
            var position = (token?.Position - (token?.Value?.Length ?? 0)) ?? 0;
            var str = token?.Type == TokenType.EOF ? "[EOF]" : token?.Value ?? "";
            var exp = expected == null ? "" : $" Expected `{expected}`.";

            return new LiteException(UNEXPECTED_TOKEN, $"Unexpected token `{str}` in position {position}.{exp}")
            {
                Position = position
            };
        }

        internal static LiteException UnexpectedToken(string message, Token token)
        {
            var position = (token?.Position - (token?.Value?.Length ?? 0)) ?? 0;

            return new LiteException(UNEXPECTED_TOKEN, message)
            {
                Position = position
            };
        }

        internal static LiteException InvalidDataType(string field, BsonValue value)
        {
            return new LiteException(INVALID_DATA_TYPE, "Invalid BSON data type '{0}' on field '{1}'.", value.Type, field);
        }

        internal static LiteException PropertyReadWrite(PropertyInfo prop)
        {
            return new LiteException(PROPERTY_READ_WRITE, "'{0}' property must have public getter and setter.", prop.Name);
        }

        internal static LiteException PropertyNotMapped(string name)
        {
            return new LiteException(PROPERTY_NOT_MAPPED, "Property '{0}' was not mapped into BsonDocument.", name);
        }

        internal static LiteException InvalidTypedName(string type)
        {
            return new LiteException(INVALID_TYPED_NAME, "Type '{0}' not found in current domain (_type format is 'Type.FullName, AssemblyName').", type);
        }
        */

    }
}
