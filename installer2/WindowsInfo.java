import VDF.VDF;
import com.sun.deploy.util.WinRegistry;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WindowsInfo {
    public static void main(String[] args) throws IOException {
        String[] files = new String[]
                {
                        "Terraria.exe",
                        "ModCompile/tModLoaderMac.exe",
                        "tModLoaderServer.exe",
                        "ModCompile/FNA.dll",
                        "ModCompile/Microsoft.CodeAnalysis.dll",
                        "ModCompile/Microsoft.CodeAnalysis.CSharp.dll",
                        "ModCompile/Mono.Cecil.Pdb.dll",
                        "ModCompile/System.Reflection.Metadata.dll",
                        "ModCompile/RoslynWrapper.dll",
                        "start-tModLoaderServer.bat",
                        "start-tModLoaderServer-steam-friends.bat",
                        "start-tModLoaderServer-steam-private.bat"
                };

        String steamPath = WinRegistry.getString(WinRegistry.HKEY_CURRENT_USER, "SOFTWARE\\Valve\\Steam", "SteamPath");

        File steamInstall = new File(steamPath + "/steamapps/appmanifest_105600.acf");
        if (steamInstall.exists()) {
            Installer.tryInstall(files, new File(steamPath + "/steamapps/common/Terraria"));
            return;
        }

        File InputVDFFile = new File(steamPath + "/config/config.vdf");
        VDF InputVDF = new VDF(InputVDFFile);
        BufferedReader buffer = new BufferedReader(new FileReader(steamPath + "/config/config.vdf"));

        String line = null;
        while ((line = buffer.readLine()) != null) {
            Pattern pattern = Pattern.compile("\"(.*?)\"");
            Matcher matcher = pattern.matcher(line);

            while (matcher.find()) {
                String key = matcher.group(1);
                if (key.contains("BaseInstallFolder")) {
                    String baseInstallFolder = InputVDF.getParent("InstallConfigStore").getParent("Software").getParent("Valve").getParent("Steam").getKey(key).toString();
                    File manifest = new File(baseInstallFolder + "/steamapps/appmanifest_105600.acf");
                    if (manifest.exists()) {
                        File terraria = new File(baseInstallFolder + "/steamapps/common/Terraria");
                        if (terraria.exists()) {
                            Installer.tryInstall(files, terraria);
                            return;
                        }
                    }
                }
            }
        }
    }
}