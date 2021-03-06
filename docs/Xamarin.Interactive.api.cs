[assembly: AssemblyConfiguration ("Release")]
[assembly: AssemblyCopyright ("Copyright 2016-2018 Microsoft. All rights reserved.\nCopyright 2014-2016 Xamarin Inc. All rights reserved.")]
[assembly: AssemblyProduct ("Xamarin.Interactive")]
[assembly: AssemblyTitle ("Xamarin.Interactive")]
[assembly: BuildInfo]
[assembly: InternalsVisibleTo ("Workbook Mac App (Desktop Profile)")]
[assembly: InternalsVisibleTo ("Workbook Mac App (Mobile Profile)")]
[assembly: InternalsVisibleTo ("workbook")]
[assembly: InternalsVisibleTo ("workbooks-server")]
[assembly: InternalsVisibleTo ("Xamarin Inspector")]
[assembly: InternalsVisibleTo ("Xamarin Workbooks Agent (WPF)")]
[assembly: InternalsVisibleTo ("Xamarin Workbooks")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Android")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Client")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Client.Console")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Client.Desktop")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.CodeAnalysis")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Console")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.DotNetCore")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Forms")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Forms.Android")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Forms.iOS")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.iOS")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Mac.Desktop")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Mac.Mobile")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Telemetry.Server")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Tests")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Tests.Android")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Tests.Core")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Tests.Mac")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Tests.Windows")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.VS")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.Wpf")]
[assembly: InternalsVisibleTo ("Xamarin.Interactive.XS")]
[assembly: InternalsVisibleTo ("Xamarin.Workbooks.Android")]
[assembly: InternalsVisibleTo ("Xamarin.Workbooks.Client.Android")]
[assembly: InternalsVisibleTo ("Xamarin.Workbooks.Client.iOS")]
[assembly: InternalsVisibleTo ("Xamarin.Workbooks.DotNetCore")]
[assembly: InternalsVisibleTo ("Xamarin.Workbooks.Forms.Android")]
[assembly: InternalsVisibleTo ("Xamarin.Workbooks.Forms.iOS")]
[assembly: InternalsVisibleTo ("Xamarin.Workbooks.iOS")]
[assembly: InternalsVisibleTo ("xic")]
[assembly: TargetFramework (".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
namespace Xamarin.Interactive
{
    [AttributeUsage (AttributeTargets.Assembly)]
    public sealed class AgentIntegrationAttribute : Attribute
    {
        public Type AgentIntegrationType {
            get;
        }

        public AgentIntegrationAttribute (Type agentIntegrationType);
    }
    [AttributeUsage (AttributeTargets.Assembly)]
    public sealed class BuildInfoAttribute : Attribute
    {
        public DateTime Date {
            get;
        }

        public string VersionString {
            get;
        }
    }
    public interface IAgent
    {
        Func<object> CreateDefaultHttpMessageHandler {
            get;
            set;
        }

        IRepresentationManager RepresentationManager {
            get;
        }

        IAgentSynchronizationContext SynchronizationContexts {
            get;
        }

        void PublishEvaluation (CodeCellId codeCellId, object result, EvaluationResultHandling resultHandling = EvaluationResultHandling.Replace);

        void RegisterResetStateHandler (Action handler);
    }
    public interface IAgentIntegration
    {
        void IntegrateWith (IAgent agent);
    }
    public interface IAgentSynchronizationContext
    {
        SynchronizationContext PeekContext ();

        SynchronizationContext PopContext ();

        SynchronizationContext PushContext (Action<Action> postHandler, Action<Action> sendHandler = null);

        SynchronizationContext PushContext (SynchronizationContext context);
    }
    public static class Utf8
    {
        public static UTF8Encoding Encoding {
            get;
        }

        public static byte[] GetBytes (string value);

        public static string GetString (byte[] bytes);

        public static string GetString (byte[] bytes, int count);

        public static string GetString (byte[] bytes, int index, int count);
    }
}
namespace Xamarin.Interactive.CodeAnalysis
{
    [Serializable]
    public struct CodeCellId : IEquatable<CodeCellId>
    {
        public static bool operator == (CodeCellId a, CodeCellId b);

        public static implicit operator CodeCellId (string id);

        public static implicit operator string (CodeCellId id);

        public static bool operator != (CodeCellId a, CodeCellId b);

        public Guid Id {
            get;
        }

        public Guid ProjectId {
            get;
        }

        public CodeCellId (Guid projectId, Guid id);

        public bool Equals (CodeCellId id);

        public override bool Equals (object obj);

        public override int GetHashCode ();

        public static CodeCellId Parse (string id);

        public override string ToString ();
    }
    [Serializable]
    public sealed class Compilation : ICompilation
    {
        public CodeCellId CodeCellId {
            get;
        }

        public EvaluationContextId EvaluationContextId {
            get;
        }

        public EvaluationEnvironment EvaluationEnvironment {
            get;
        }

        public AssemblyDefinition ExecutableAssembly {
            get;
        }

        public bool IsResultAnExpression {
            get;
        }

        public IReadOnlyList<AssemblyDefinition> References {
            get;
        }

        public int SubmissionNumber {
            get;
        }

        public Compilation (CodeCellId codeCellId, int submissionNumber, EvaluationContextId evaluationContextId, EvaluationEnvironment evaluationEnvironment, bool isResultAnExpression, AssemblyDefinition executableAssembly, IReadOnlyList<AssemblyDefinition> references);
    }
    public class EvaluationContextGlobalObject
    {
        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "Clear all previous REPL results", ShowReturnType = false, LiveInspectOnly = true)]
        public static readonly Guid clear;

        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "Get or set the current thread culture")]
        public static CultureInfo CurrentCulture {
            get;
            set;
        }

        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "Get or set the current thread culture by name")]
        public static string CurrentCultureName {
            get;
            set;
        }

        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "This help text", ShowReturnType = false)]
        public object help {
            get;
        }

        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "Direct public access to the agent powering the interactive session")]
        public IAgent InteractiveAgent {
            get;
        }

        [EditorBrowsable (EditorBrowsableState.Never)]
        public T __AssignmentMonitor<T> (T value, string symbolName, string nodeType, int spanStart, int spanEnd);

        public T GetObject<T> (long handle);

        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "Shows declared global variables", ShowReturnType = false)]
        public object GetVars ();

        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "Render an image from a path or URI")]
        public static Image Image (Uri uri);

        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "Render an image from a path or URI, or SVG data")]
        public static Image Image (string uriOrTextData);

        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "Render an image from raw data")]
        public static Image Image (byte[] data);

        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "Render an image from a stream")]
        public static Task<Image> ImageAsync (Stream stream);

        [EvaluationContextGlobalObject.InteractiveHelpAttribute (Description = "Uses a Stopwatch to time the specified action delegate")]
        public static TimeSpan Time (Action action);
    }
    [Serializable]
    public struct EvaluationContextId : IEquatable<EvaluationContextId>
    {
        public static bool operator == (EvaluationContextId a, EvaluationContextId b);

        public static implicit operator EvaluationContextId (int id);

        public static bool operator != (EvaluationContextId a, EvaluationContextId b);

        public bool Equals (EvaluationContextId id);

        public override bool Equals (object obj);

        public override int GetHashCode ();

        public override string ToString ();
    }
    [Serializable]
    public struct EvaluationEnvironment
    {
        public FilePath WorkingDirectory {
            get;
        }

        public EvaluationEnvironment (FilePath workingDirectory);
    }
    public enum EvaluationPhase
    {
        None,
        Compiled,
        Evaluated,
        Represented,
        Completed
    }
    public enum EvaluationResultHandling
    {
        Replace,
        Append
    }
    public interface ICompilation
    {
        AssemblyDefinition Assembly {
            get;
        }

        CodeCellId CodeCellId {
            get;
        }
    }
    public interface IEvaluation
    {
        ICompilation Compilation {
            get;
        }

        EvaluationPhase Phase {
            get;
        }

        object Result {
            get;
        }
    }
    public interface IEvaluationContext
    {
        IObservable<IEvaluation> Evaluations {
            get;
        }

        EvaluationContextId Id {
            get;
        }
    }
    public interface IEvaluationContextIntegration
    {
        void IntegrateWith (IEvaluationContext evaluationContext);
    }
    [Serializable]
    public sealed class TargetCompilationConfiguration
    {
        public string[] DefaultUsings {
            get;
            set;
        }

        public string[] DefaultWarningSuppressions {
            get;
            set;
        }

        public EvaluationContextId EvaluationContextId {
            get;
            set;
        }

        public AssemblyDefinition GlobalStateAssembly {
            get;
            set;
        }

        public string GlobalStateTypeName {
            get;
            set;
        }

        public TargetCompilationConfiguration ();
    }
}
namespace Xamarin.Interactive.CodeAnalysis.Events
{
    public interface ICodeCellEvent
    {
        CodeCellId CodeCellId {
            get;
        }
    }
}
namespace Xamarin.Interactive.CodeAnalysis.Resolving
{
    [Serializable]
    public sealed class AssemblyContent
    {
        public byte[] DebugSymbols {
            get;
        }

        public FilePath Location {
            get;
        }

        public byte[] PEImage {
            get;
        }

        public Stream OpenPEImage ();
    }
    [Serializable]
    public sealed class AssemblyDefinition
    {
        public AssemblyContent Content {
            get;
        }

        public AssemblyEntryPoint EntryPoint {
            get;
        }

        public AssemblyDependency[] ExternalDependencies {
            get;
        }

        public bool HasIntegration {
            get;
        }

        public AssemblyIdentity Name {
            get;
        }

        public AssemblyDefinition (AssemblyIdentity name, FilePath location, string entryPointType = null, string entryPointMethod = null, byte[] peImage = null, byte[] debugSymbols = null, AssemblyDependency[] externalDependencies = null, bool hasIntegration = false);

        public AssemblyDefinition (AssemblyName name, FilePath location, string entryPointType = null, string entryPointMethod = null, byte[] peImage = null, byte[] debugSymbols = null, AssemblyDependency[] externalDependencies = null, bool hasIntegration = false);
    }
    [Serializable]
    public struct AssemblyDependency
    {
        public byte[] Data {
            get;
        }

        public FilePath Location {
            get;
        }
    }
    [Serializable]
    public struct AssemblyEntryPoint
    {
        public string MethodName {
            get;
        }

        public string TypeName {
            get;
        }
    }
    [Serializable]
    public sealed class AssemblyIdentity
    {
        public static implicit operator AssemblyName (AssemblyIdentity assemblyIdentity);

        public string FullName {
            get;
        }

        public string Name {
            get;
        }

        public Version Version {
            get;
        }

        public bool Equals (AssemblyIdentity other);

        public override bool Equals (object obj);

        public override int GetHashCode ();

        public override string ToString ();
    }
}
namespace Xamarin.Interactive.CodeAnalysis.Workbooks
{
    public static class EvaluationContextGlobalsExtensions
    {
        public static VerbatimHtml AsHtml (this string str);
    }
}
namespace Xamarin.Interactive.Core
{
    [TypeConverter (typeof(FilePath.FilePathTypeConverter))]
    [Serializable]
    public struct FilePath : IComparable<FilePath>, IComparable, IEquatable<FilePath>
    {
        public static bool operator == (FilePath a, FilePath b);

        public static implicit operator FilePath (string path);

        public static implicit operator string (FilePath path);

        public static bool operator != (FilePath a, FilePath b);

        public bool DirectoryExists {
            get;
        }

        public bool Exists {
            get;
        }

        public string Extension {
            get;
        }

        public bool FileExists {
            get;
        }

        public long FileSize {
            get;
        }

        public string FullPath {
            get;
        }

        public bool IsNull {
            get;
        }

        public bool IsRooted {
            get;
        }

        public string Name {
            get;
        }

        public string NameWithoutExtension {
            get;
        }

        public FilePath ParentDirectory {
            get;
        }

        public FilePath (string path);

        public static FilePath Build (params string[] paths);

        public FilePath ChangeExtension (string extension);

        public string Checksum ();

        public FilePath Combine (params string[] paths);

        public int CompareTo (FilePath other);

        public int CompareTo (object obj);

        public DirectoryInfo CreateDirectory ();

        public IEnumerable<FilePath> EnumerateDirectories (string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly);

        public IEnumerable<FilePath> EnumerateFiles (string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly);

        public bool Equals (FilePath other);

        public override bool Equals (object obj);

        public override int GetHashCode ();

        public FilePath GetRelativePath (FilePath relativeToPath);

        public static FilePath GetTempPath ();

        public bool IsChildOfDirectory (FilePath parentDirectory);

        public FileStream OpenRead ();

        public override string ToString ();
    }
}
namespace Xamarin.Interactive.Logging
{
    public static class Log
    {
        public static bool IsInitialized {
            get;
        }

        public static void Commit (LogLevel level, string tag, string message, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Critical (string tag, Exception exception, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Critical (string tag, string message, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Critical (string tag, string message, Exception exception, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Debug (string tag, string message, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Error (string tag, Exception exception, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Error (string tag, string message, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Error (string tag, string message, Exception exception, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Info (string tag, string message, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Verbose (string tag, string message, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Warning (string tag, Exception exception, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Warning (string tag, string message, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);

        public static void Warning (string tag, string message, Exception exception, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0);
    }
    [Serializable]
    public struct LogEntry
    {
        public string CallerFilePath {
            get;
        }

        public int CallerLineNumber {
            get;
        }

        public string CallerMemberName {
            get;
        }

        public LogLevel Level {
            get;
        }

        public string Message {
            get;
        }

        public TimeSpan RelativeTime {
            get;
        }

        public string Tag {
            get;
        }

        public DateTime Time {
            get;
        }

        public override string ToString ();
    }
    [Serializable]
    public enum LogLevel
    {
        Verbose,
        Debug,
        Info,
        Warning,
        Error,
        Critical
    }
}
namespace Xamarin.Interactive.Representations
{
    [Serializable]
    public sealed class Color : IFallbackRepresentationObject, ISerializableObject, IEquatable<Color>
    {
        public double Alpha {
            get;
        }

        public double Blue {
            get;
        }

        public ColorSpace ColorSpace {
            get;
        }

        public double Green {
            get;
        }

        public double Red {
            get;
        }

        public Color (double red, double green, double blue, double alpha = 1.0);

        public bool Equals (Color other);

        public override bool Equals (object obj);

        public override int GetHashCode ();
    }
    [Serializable]
    public enum ColorSpace
    {
        Rgb
    }
    [Serializable]
    public sealed class GeoLocation : IRepresentationObject, ISerializableObject
    {
        public double? Altitude {
            get;
        }

        public double? Bearing {
            get;
        }

        public double? HorizontalAccuracy {
            get;
        }

        public double Latitude {
            get;
        }

        public double Longitude {
            get;
        }

        public double? Speed {
            get;
        }

        public DateTime Timestamp {
            get;
        }

        public double? VerticalAccuracy {
            get;
        }

        public GeoLocation (double latitude, double longitude, double? altitude = null, double? horizontalAccuracy = null, double? verticalAccuracy = null, double? speed = null, double? bearing = null, DateTime timestamp = default(DateTime));
    }
    [Serializable]
    public sealed class GeoPolyline : IRepresentationObject, ISerializableObject
    {
        public GeoLocation[] Points {
            get;
        }

        public GeoPolyline (GeoLocation[] points);
    }
    [Serializable]
    public sealed class Image : IRepresentationObject, ISerializableObject
    {
        public byte[] Data {
            get;
        }

        public ImageFormat Format {
            get;
        }

        public int Height {
            get;
        }

        public double Scale {
            get;
        }

        public int Width {
            get;
        }

        public Image (ImageFormat format, byte[] data, int width = 0, int height = 0, double scale = 1.0);

        public static Image FromData (byte[] data, int width = 0, int height = 0);

        public static Image FromData (string data, int width = 0, int height = 0);

        public static async Task<Image> FromStreamAsync (Stream stream, CancellationToken cancellationToken = default(CancellationToken));

        public static Image FromSvg (string svgData, int width = 0, int height = 0);

        public static Image FromUri (string uri, int width = 0, int height = 0);
    }
    [Serializable]
    public enum ImageFormat
    {
        Unknown,
        Png,
        Jpeg,
        Gif,
        Rgba32,
        Rgb24,
        Bgra32,
        Bgr24,
        Uri,
        Svg
    }
    public interface IRepresentationManager
    {
        void AddProvider (RepresentationProvider provider);

        void AddProvider (string typeName, Func<object, object> handler);

        void AddProvider<T> (Func<T, object> handler);
    }
    [Serializable]
    public sealed class Point : IRepresentationObject, ISerializableObject
    {
        public double X {
            get;
        }

        public double Y {
            get;
        }

        public Point (double x, double y);
    }
    [Serializable]
    public sealed class Rectangle : IRepresentationObject, ISerializableObject
    {
        public double Height {
            get;
        }

        public double Width {
            get;
        }

        public double X {
            get;
        }

        public double Y {
            get;
        }

        public Rectangle (double x, double y, double width, double height);
    }
    [Serializable]
    public struct Representation : IRepresentationObject, ISerializableObject
    {
        public static readonly Representation Empty;

        public bool CanEdit {
            get;
        }

        public object Value {
            get;
        }

        public Representation (object value, bool canEdit = false);
    }
    public abstract class RepresentationProvider
    {
        public virtual bool HasSensibleEnumerator (IEnumerable enumerable);

        public virtual IEnumerable<object> ProvideRepresentations (object obj);

        public virtual bool ShouldReadMemberValue (IRepresentedMemberInfo representedMemberInfo, object obj);

        public virtual bool ShouldReflect (object obj);

        public virtual bool TryConvertFromRepresentation (IRepresentedType representedType, object[] representations, out object represented);
    }
    [Serializable]
    public sealed class Size : IRepresentationObject, ISerializableObject
    {
        public double Height {
            get;
        }

        public double Width {
            get;
        }

        public Size (double width, double height);
    }
    [Serializable]
    public sealed class VerbatimHtml : IRepresentationObject, ISerializableObject
    {
        public VerbatimHtml (string content);

        public VerbatimHtml (StringBuilder builder);

        public override string ToString ();
    }
}
namespace Xamarin.Interactive.Representations.Reflection
{
    public interface IRepresentedMemberInfo
    {
        bool CanWrite {
            get;
        }

        IRepresentedType DeclaringType {
            get;
        }

        RepresentedMemberKind MemberKind {
            get;
        }

        IRepresentedType MemberType {
            get;
        }

        string Name {
            get;
        }
    }
    public interface IRepresentedType
    {
        IRepresentedType BaseType {
            get;
        }

        string Name {
            get;
        }

        Type ResolvedType {
            get;
        }
    }
    [Serializable]
    public enum RepresentedMemberKind : byte
    {
        None,
        Field,
        Property
    }
}
namespace Xamarin.Interactive.Serialization
{
    public interface ISerializableObject
    {
        void Serialize (ObjectSerializer serializer);
    }
    public sealed class ObjectSerializer
    {
        public void Object (ISerializableObject value);

        public void Property (string name, bool value);

        public void Property (string name, byte[] value);

        public void Property (string name, byte[] value, PropertyOptions options);

        public void Property (string name, double value);

        public void Property (string name, float value);

        public void Property (string name, IEnumerable<bool> value);

        public void Property (string name, IEnumerable<byte[]> value);

        public void Property (string name, IEnumerable<double> value);

        public void Property (string name, IEnumerable<float> value);

        public void Property (string name, IEnumerable<int> value);

        public void Property (string name, IEnumerable<string> value);

        public void Property (string name, int value);

        public void Property (string name, string value);

        public void Property (string name, string value, PropertyOptions options);

        public void Property<TSerializable> (string name, IEnumerable<TSerializable> value) where TSerializable : ISerializableObject;

        public void Property<TSerializable> (string name, TSerializable value) where TSerializable : ISerializableObject;
    }
    [Flags]
    public enum PropertyOptions
    {
        None = 0,
        SerializeIfNull = 1,
        SerializeIfEmpty = 2,
        Default = 2
    }
}
