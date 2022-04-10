# Tugas Besar Unity IF3210 Platform-based Application Development
> Survival Shooter : Extended

## Table of contents
  - [Description](#description)
  - [Requirements](#requirements)
  - [How to Use](#how-to-use)
  - [Contributors](#contributors)

## Deskripsi Aplikasi

Survival Shooter : Extended merupakan ekstensi dari permainan [Survival Shooter](https://learn.unity.com/tutorial/survival-shooter-training-day-phases?) yang diimplementasi menggunakan [Unity Game Engine](https://unity.com/), spesifiknya Unity3D.

Secara umum, terdapat 3 mode permainan hasil implementasi kami.
 
### Zen mode 

Pada Zen Mode pemain diminta untuk bertahan selama mungkin dan enemy di spawn secara terus menerus sesuai interval spawn yang dimiliki tiap tipe enemy.

Score pada Zen Mode merupakan waktu yang menyatakan berapa lama pemain dapat bertahan pada permainan (Survival Time). 
 
### Wave Mode

Pada Wave Mode pemain diminta untuk menyelesaikan setiap wave yang ada pada permainan dengan mengalahkan set dari Enemy yang muncul tiap Wave. 
 
### Sudden Death Mode

Mode ini mirip seperti Zen Mode, perbedaannya adalah pada Sudden Death Mode pemain hanya memiliki 1 kali kesempatan untuk terkena damage dari lawan. 
 
## Cara Kerja
Cara kerja permainan secara umum mirip dengan cara kerja pembelajaran survival shooter yang disediakan unity. Namun terdapat berbagai perbedaan untuk memenuhi spesifikasi tugas besar. Berikut penjelasan untuk setiap spesifikasinya. 
 
### Atribut Player 
 
 
### Orb
Terdapat tiga macam orb yaitu red orb, yellow orb, dan green orb. Red orb memiliki efek penambahan Health Point (HP) pemain sebesar 25 point. Yellow Orb memiliki efek penambahan movement speed pemain sebesar 3 point. Green Orb memiliki efek penambahan damage per shoot pemain sebesar 10 point. Orb memiliki Orb factory untuk instantiate orb prefab. 
### Additional Mobs
### Game Mode 
#### Zen Mode 
#### Wave Mode 
### Weapon Upgrade 
### Local Scoreboard
### Main Menu
### Game Over 
### Bonus 
#### Menambah Game Mode
#### Menambah upgrade Weapon
 
 
## Library
Newtonsoft json 
-> Digunakan untuk serialize class c# ke json dan deserialize json ke class c#. Serialize / deserialize ini digunakan untuk keperluan menyimpan data scoreboard pemain ke json. Kemudian, datanya disimpan ke playerprefs.
Sketchfab for unity
-> Digunakan untuk import 3d model ke unity agar lebih mudah daripada menggunakan web sketchfab
 
## Screenshot
![Screenshot Zen Mode](./Docs/ZenMode.jpg)
![Screenshot Wave Mode](./Docs/WaveMode.jpg)
![Screenshot Sudden Death Mode](./Docs/SuddenDeathMode.jpg)
 
## Pembagian Kerja Anggota Kelompok
| Nama     | NIM     | Pembagian kerja     |
| ------------- | ------------- | -------- |
| Mohammad Sheva Almeyda Sofjan | 13519018 | Additional Mobs (Skeleton, Bomber, Boss, Slime), Zen Mode, Wave Mode |
| Muhammad Fikri N.          | 13519069        | tugas   |
| Muhammad Tamiramin Hayat Suhendar | 13519129 | Initial Git + Attribute Player + Weapon Level up 
 
 
 
## Credits
 
- Unity Learn
- Agate Academy