# Taki7o7's OpenXR Runtime-Switcher
![GitHub release (latest by date)](https://img.shields.io/github/v/release/WaGi-Coding/OpenXR-Runtime-Switcher?label=latest%20release&style=for-the-badge)
![GitHub all releases](https://img.shields.io/github/downloads/WaGi-Coding/OpenXR-Runtime-Switcher/total?label=Github%20Release%20Downloads&style=for-the-badge)

![GitHub Repo stars](https://img.shields.io/github/stars/WaGi-Coding/OpenXR-Runtime-Switcher?style=social)


<p align="center">
  <a href="https://github.com/WaGi-Coding/OpenXR-Runtime-Switcher/releases/"><img alt="Download" src="https://i.imgur.com/IMSXFnA.png"/></a>
</p>

---

<p align="center">
  <img src="https://i.imgur.com/iHKCJT4.png">
</p>

<p align="center">
  Allows you to quickly switch your System Default OpenXR Runtime between existing ones (currently SteamVR, Oculus/Meta, ViveVR, Windows Mixed Reality & Varjo) if installed & custom ones, which you can add manually to the program.
</p>


<p align="center">
  <img src="https://i.imgur.com/hBm4O18.png">
</p>

<p align="center">
  <img src="https://i.imgur.com/9RtXsTt.png">
</p>


<p align="center">
  I've made this because for example SteamVR only gives you the option to set it's Runtime as System Default OXR Runtime via the Developer Tab, when you've a Headset connected to it - which is/was annoying.
</p>

<p align="center">
  Let me know if you find any bugs or if you have any questions. Here in Issues tab, or via Discord: Taki7o7#0860
</p>

<p align="center">
  Also if you want me to add more Runtime "Presets".
</p>


## Additional Info

- The presets try to automatically detect the programs with a runtime via the registry key, in order to make the detection work with different installation paths.
- The program does not check the validity of a runtimes json file!
- This program only changes the SYSTEM DEFAULT OpenXR Runtime, a Game could internally pick/require a/the non System Default one manually!
- The program needs administrator rights, in order to set the runtime registry key!
