import keyboard # for keylogs
import json
import subprocess

class KeyLogger:

    def readJson(self):
        # JSON file
        f = open ('shortcut_config.json', "r")

        # Reading from file
        data = json.loads(f.read())

        # Closing file
        f.close()

        return data
    
    def callback(self, event):
        hotkey = keyboard.read_hotkey() 
        print(hotkey)
        data = self.readJson()
        for Shortcut in data['Shortcuts']:
            # print(hotkey)            
            # print(Shortcut['ShortcutString'])
            if Shortcut['ShortcutString'] == hotkey:
                subprocess.call(Shortcut['ProgramPath'],shell=True)
        keyboard.stash_state() 

    def start(self):

        keyboard.on_release(callback=self.callback)
        keyboard.wait()

if __name__ == "__main__":
    keylogger = KeyLogger()
    # keylogger.start()
    data = keylogger.readJson()
    while True:
        for Shortcut in data['Shortcuts']:
            if keyboard.is_pressed(Shortcut["ShortcutString"]):
                subprocess.call(Shortcut['ProgramPath'],shell=True)