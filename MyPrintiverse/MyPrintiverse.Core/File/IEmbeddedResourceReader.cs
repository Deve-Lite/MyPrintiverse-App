namespace MyPrintiverse.Core.File;

/// <summary>
/// Reads embedded resources.
/// </summary>
public interface IEmbeddedResourceReader
{
	/// <summary>
	/// Get resource file stream by file name e.g "filename.fileextension" or full file path in assembly. Resource full path can be find using <see cref="GetLoadedEmbeddedResources"/>.
	/// </summary>
	/// <param name="resourcePath">Resource file name e.g "filename.fileextension" or full file path in assembly.</param>
	/// <exception cref="InvalidOperationException" />
	/// <returns>resource stream if resource with provided path exists, otherwise <seealso cref="InvalidOperationException"/>.</returns>
	/// 
	public Stream GetResourceStream(string resourcePath);

	/// <summary>
	/// Get assembly all embedded resources.
	/// </summary>
	/// <returns>embedded resources if app is in debug mode, otherwise error message.</returns>
	public List<string> GetLoadedEmbeddedResources();
}