1. Mantošana (Inheritance):
- Izveidota Character bāzes klase, no kuras manto Player, Enemy, Berserker, Puble.

2. Enkapsulācija (Encapsulation):
- Mainīgie health, shield, weapon ir private/protected.
- Piekļuve notiek caur getter metodēm (GetHealth(), IsAlive(), u.c.)

3. Polimorfisms (Polymorphism):
- Attack() metode pārrakstīta (override) klasēs Player, Berserker, Puble.
- Tiek izmantots Weapon.ApplyEffect, kas strādā dažādi atkarībā no ieroča veida.

4. Abstrakcija (Abstraction):
- Izveidota abstrakta klase Weapon ar abstraktu metodi ApplyEffect().
- Trīs klases manto no Weapon: BasicWeapons, PoisonWeapon, MagicWand.


Realizētais papilduzdevums

✔️ 3 ieroču tipi:
- BasicWeapon — standarta uzbrukums
- PoisonWeapon — papildus kaitējums ar indi
- MagicWand — heal speletaju, bet to var lietot tikai reizi 3 gājienos (cooldown) + dod damage to enemy

✔️ 2 dažādi pretinieki:
- Berserker — spēcīgāks uzbrukums (papildus +5 dmg)
- Puble — vājāks uzbrukums, bet uzbrūk divreiz katrā gājienā