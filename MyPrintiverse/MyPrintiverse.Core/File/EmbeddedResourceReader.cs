using System.Reflection;

namespace MyPrintiverse.Core.File
{
	/// <inheritdoc />
	public class EmbeddedResourceReader : IEmbeddedResourceReader
	{
		private readonly Assembly _assembly;

		public EmbeddedResourceReader(Assembly assembly)
		{
			_assembly = assembly;
		}

		public Stream GetResourceStream(string resourcePath)
		{
			var resourceStream = _assembly.GetManifestResourceStream(resourcePath);
			
			if (resourceStream != null)
				return resourceStream;

			var resourceName = _assembly
				.GetManifestResourceNames()
				.Single(str => str.EndsWith(resourcePath));

			return GetResourceStream(resourceName);
		}

		public List<string> GetLoadedEmbeddedResources()
		{
#if DEBUG
			var i = 1;

			return _assembly
				.GetManifestResourceNames()
				.Select(res => $"Find resource nr. {i++}: {res}\n")
				.ToList();
#else
			return new List<string> { "App is not in debug mode, you can't open loaded resources." };
#endif
		}
	}
}
