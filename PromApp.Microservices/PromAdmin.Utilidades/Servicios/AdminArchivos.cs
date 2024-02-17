namespace PromAdmin.Utilidades.Servicios;

public class AdminArchivos
{
    public static string ReturnFolderLevel(string path, int level)
    {
        var pathResult = path;
        for (var i = 0; i < level; i++)
        {
            pathResult = Directory.GetParent(pathResult)!.FullName;
        }

        return pathResult;
    }
}