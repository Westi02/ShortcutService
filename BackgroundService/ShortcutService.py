import keyboard # for keylogs
import json
import subprocess
import os
from win32com.shell import shell, shellcon


def readJson():
    # JSON file
    path = f"{shell.SHGetFolderPath(0, shellcon.CSIDL_PERSONAL, None, 0)}\shortcut_config.json"
    f = open (path, "r")

    # Reading from file
    data = json.loads(f.read())

    # Closing file
    f.close()

    return data

if __name__ == "__main__":
    data = readJson()
    while True:
        for Shortcut in data['Shortcuts']:
            if not Shortcut["ShortcutString"] == "":
                if keyboard.is_pressed(Shortcut["ShortcutString"]):
                    if not Shortcut["ProgramPath"] == "":
                        subprocess.call(Shortcut['ProgramPath'],shell=True)