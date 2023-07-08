import keyboard 
import json
import subprocess
from win32com.shell import shell, shellcon

class Keylogger:
    def readJson(self):
        # JSON file
        path = f"{shell.SHGetFolderPath(0, shellcon.CSIDL_PERSONAL, None, 0)}\shortcut_config.json"
        f = open (path, "r")

        # Reading from file
        self.configdata = json.loads(f.read())

        # Closing file
        f.close()

    def callback(self, event):
        for Shortcut in self.configdata['Shortcuts']:
            if not Shortcut["ShortcutString"] == "":
                if keyboard.is_pressed(Shortcut["ShortcutString"]):
                    if not Shortcut["ProgramPath"] == "":
                        subprocess.call(Shortcut['ProgramPath'],shell=True)

    def start(self):
        self.readJson()
        keyboard.on_press(callback=self.callback)
        keyboard.wait()

if __name__ == "__main__":
    keylogger = Keylogger()
    keylogger.start()