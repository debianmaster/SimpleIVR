SimpleIVR
=========

Basic IVR using Sim900 module + AT commands + c#.net

<img src="https://raw.github.com/debianmaster/SimpleIVR/master/Connections.jpg"/>
<img src="https://raw.github.com/debianmaster/SimpleIVR/master/Connections2.jpg"/>

<h3> Usage </h3>
<ol>
<li> Connect Sim900 GSM module to PC via RS232 cable </li>
<li> Power up GSM module, in my case i used 12 V 1 Amp adapter as power source. (You's might differ) </li>
<li> Run SimpleIVR.exe program </li>
</ol>

This Exe connects to Com1 port and checks if there is a RING on Serial / GSM (every 1 second) and if there is a Incoming call (RING)
Then answers the call issuing  <b>ATA</b>  command.

The analog speaker out from PC acts as MIC input for GSM. 

A text to speech module (inside Program.cs)   provides the necessary audio.

After completion of Voice message call is disconnected using  <b> ATH </b> command.

Please refer Images.
