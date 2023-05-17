# Common Extensions

This is a collection of common extensions for various data types and classes in C#.

## Table of Contents
- [String Extensions](#string-extensions)
- [DateTime Extensions](#datetime-extensions)
- [Double Extensions](#double-extensions)
- [Object Extensions](#object-extensions)
- [Type Extensions](#type-extensions)
- [Array Extensions](#array-extensions)
- [Stream Extensions](#stream-extensions)
- [Dictionary Extensions](#dictionary-extensions)
- [IEnumerable Extensions](#ienumerable-extensions)
- [String Manipulation Extensions](#string-manipulation-extensions)
- [Type Checking Extensions](#type-checking-extensions)
- [Other Extensions](#other-extensions)
- [Boolean Extensions](#boolean-extensions)
- [Numeric Extensions](#numeric-extensions)
- [DateTime Extensions](#datetime-extensions)
- [Type Extensions](#type-extensions)
- [String Extensions](#string-extensions)
- [Guid Extensions](#guid-extensions)
- [String Manipulation Extensions](#string-manipulation-extensions)
- [Process Extensions](#process-extensions)
- [Exception Extensions](#exception-extensions)
- [Encoding Extensions](#encoding-extensions)
- [Xml Extensions](#xml-extensions)
- [IDisposable Extensions](#idisposable-extensions)
- [Other Extensions](#other-extensions)

## String Extensions

- `Assigned()`: Checks if the string is not null or empty.
- `NotAssigned()`: Checks if the string is null or empty.
- `RegexReplace(string pattern, string replacement)`: Performs a regular expression replacement on the string.

## DateTime Extensions

- `Assigned()`: Checks if the DateTime object is assigned (greater than DateTime.MinValue).
- `NotAssigned()`: Checks if the DateTime object is not assigned (equal to DateTime.MinValue).
- `OnlyDate()`: Returns a new DateTime object with the time portion set to midnight.

## Double Extensions

- `Assigned()`: Checks if the double value is not NaN.
- `NotAssigned()`: Checks if the double value is NaN.
- `ToVal()`: Converts a nullable double value to a double, returning the default value if null.

## Object Extensions

- `Assigned()`: Checks if the object is not null or DBNull.
- `NotAssigned()`: Checks if the object is null or DBNull.
- `RootNamespace()`: Retrieves the root namespace of the assembly containing the object.

## Type Extensions

- `ToType()`: Returns the underlying type of a nullable type, or the original type if not nullable.
- `IsBaseType(Type parent, Type child)`: Checks if the child type is a derived type of the parent type.

## Array Extensions

- `ValidArray()`: Checks if the array is assigned and has a length greater than zero.

## Stream Extensions

- `StreamToByteArray()`: Converts a stream to a byte array.
- `ToMemoryStream()`: Creates a new memory stream from a byte array.
- `StreamToStr()`: Converts the contents of a memory stream to a base64-encoded string.
- `StrToStream()`: Initializes a memory stream from a base64-encoded string.
- `Clone<T>(Stream input)`: Creates a binary copy of a stream.

## Dictionary Extensions

- `Value<TKey, TValue>(IDictionary<TKey, TValue> list, TKey key)`: Gets the value associated with the specified key.

## IEnumerable Extensions

- `ToNewList<T>(this IList list)`: Creates a new List<T> from an IList object.
- `ToNewList<T>(this IEnumerator enumerator)`: Creates a new List<T> from an IEnumerator object.
- `ToNewList(this IEnumerator enumerator)`: Creates a new ArrayList from an IEnumerator object.

## String Manipulation Extensions

- `IncrementLastChar()`: Increments the last character of a string.
- `AsciiEncodeToBase64()`: Encodes a string to a base64-encoded ASCII string.
- `AsciiDecodeFromBase64()`: Decodes a base64-encoded ASCII string to a string.
- `ReverseString()`: Reverses the characters in a string.

## Type Checking Extensions

- `IsAlphaNumeric()`: Checks if a type is a char or string.
- `IsPrimitiveNumericOrString.

## Boolean Extensions

- `IsBoolean(this Type dataType)`: Checks if the type is a boolean type.

## Numeric Extensions

- `IsNumeric(this Type dataType)`: Checks if the type is a numeric type.
- `IsFloating(this Type dataType)`: Checks if the type is a floating-point numeric type.

## DateTime Extensions

- `IsDateTime(this Type dataType)`: Checks if the type is DateTime.
- `CropMilliSeconds(this DateTime source)`: Truncates the milliseconds part of a DateTime object.
- `CropMilliSeconds(this DateTimeOffset source)`: Truncates the milliseconds part of a DateTimeOffset object.
- `CropSeconds(this DateTime source)`: Truncates the seconds and milliseconds part of a DateTime object.
- `CropSeconds(this DateTimeOffset source)`: Truncates the seconds and milliseconds part of a DateTimeOffset object.
- `CropMinutes(this DateTime source)`: Truncates the minutes, seconds, and milliseconds part of a DateTime object.
- `CropMinutes(this DateTimeOffset source)`: Truncates the minutes, seconds, and milliseconds part of a DateTimeOffset object.

## Type Extensions

- `IsInterfaceSupported(this Type srcType, Type intfType)`: Checks if the source type implements a specific interface.

## String Extensions

- `ReverseString(this string str)`: Reverses the characters in a string.
- `ReturnAbsolutePath(this string app)`: Returns the absolute path of a URL, without the last slash if the app is a URL.
- `ValidateEmail(this string email)`: Validates if a string is a valid email address.

## Guid Extensions

- `ToGUID(this string guidStr)`: Converts a string to a GUID.

## String Manipulation Extensions

- No methods provided.

## Process Extensions

- `GetCurrentProcessID()`: Gets the ID of the current process.
- `GetCurrentProcessIdentityName()`: Gets the name of the current process's identity.
- `GetCurrentProcessName()`: Gets the name of the current process.
- `GetMachineName()`: Gets the name of the current machine.
- `GetMachineDomainName()`: Gets the domain name of the current machine.
- `GetHostIPv4Address(string hostName = "")`: Gets the IPv4 address of a given hostname.
- `TryGetProcess(int pid, out Process process)`: Tries to get a process with the specified ID.
- `ProcessIsRunning(int pid)`: Checks if a process with the specified ID is running.
- `GetRunningProcess(int pid)`: Gets a running process with the specified ID.
- `ProcessHasExited(Process process, Boolean throwUnknownEx = false)`: Checks if a process has exited.
  
## Exception Extensions

- `ActualExceptionIs(this Exception ex, Type comparedException)`: Checks if the actual exception type or any of its inner exceptions match the specified type.
- `ActualExceptionIs<T>(this Exception ex) where T : Exception`: Checks if the actual exception type or any of its inner exceptions match the specified type.

## Encoding Extensions

- `Base64Encode(this string plainText)`: Encodes a string to Base64.
- `Base64Decode(this string base64EncodedData, bool ifNotBase64StrReturnEncodedData = false)`: Decodes a Base64 encoded string.

## Xml Extensions

- `ReadXmlValue<T>(this XmlDocument doc, string key, T defaultValue = default(T))`: Reads a value from an XML document based on the provided key.

## IDisposable Extensions

- `DisposeAndNull(this IDisposable o)`: Disposes an object and sets it to null.

## Other Extensions

- `ParseGuidList(string data)`: Parses a string and returns a list of Guids.



