# RGB Fusion Monoc

For those who can't access RGB Header Settings at Windows level.

## Why

I've made this little program because I'm owner of Gigabyte B360 HD3 (which does not support official app to control leds).

It uses SDK made by Gigabyte named RGB Fusion.

## Usage

To use this, go look at [Releases Page](https://github.com/K4CZP3R/RGB-Fusion-Monoc/releases) and download .exe
But before this, look at Dependencies to know what you need to make it run!

## Dependencies

You will need `GLedApi.dll` and `ycc.dll` from [Gigabyte's RGB Fusion SDK website](https://www.gigabyte.com/mb/rgb/sdk)

### Tested SDK Versions
- [B18.0206.1.zip](https://www.gigabyte.com/WebPage/332/images/B18.0206.1.zip)
  - Gigabyte B360 HD3

### Running and examples

Usage:
```
.\RGB-Fusion-Monoc.exe R G B
```
Values R, G and B can be 1 (on) or 0 (off)


Set Red LED on and turn Green and Blue off

```
.\RGB-Fusion-Monoc.exe 1 0 0
```
