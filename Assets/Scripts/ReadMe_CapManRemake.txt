ReadMe - 30/03 

Rendu Jeu d'arcade Cap-Man


Désolé pour la qualité du rendu, comme les commit vont le montrer, j'ai un peu rien fait et j'ai attendu le dernier moment pour travailler.
Néamoins il y a quand meme du contenu à regarder par rapport à mon architecture et mes features.

-------------------------------------------------


Règle modifié sur ce remake :
1 - Pac-Man n'avance pas naturellement (controller plus libre en prévision de la 2eme règle).
2 - Tout les fantomes ont la même couleur, elle change en fonction du level et chaque couleur possède son propre comportement.


-------------------------------------------------

Features existantes 
- Controller de pac-man
- Système de score avec les Pac-Gommes
- Système de TP sur le bord de la map (droite/gauche)
- Generation du Grid, des murs et des pg
- Rotation de la couleur du level et les comportements associés
- Système de vie du pac man 
- Game Phases avec victoire/défaite
- Relation pac-man/ghost (super pacgomme qui tue les ghosts et mort du player lors de la collision)
- Architecture du comportement des ghosts 


Manquant :
Déplacement et comportement complet des ghosts
Sound Design
Visuels du jeu
Lights

---------------------------------------------------

==> Prévu d'utiliser le système A* avec mon grid pour le déplacement des ghosts dans la partie pour un pathing plus précis (surement en place d'ici ce weekend)


