namespace SDB.Core
{
    public readonly struct Result<T>
    {
        public readonly bool Ok;
        public readonly T Value;
        public readonly string Error;

        Result(bool ok, T value, string error) { Ok = ok; Value = value; Error = error; }

        public static Result<T> Success(T value) => new(true, value, null);
        public static Result<T> Fail(string error) => new(false, default, error);
    }
}
