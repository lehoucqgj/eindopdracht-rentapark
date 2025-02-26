namespace RentAPark.Domain.Exceptions {
    public class RollBackException : Exception {
        public RollBackException(string message) : base(message) { }
        public RollBackException(string message, Exception innerException) : base(message, innerException) { }
    }
}
