.model small
.stack 100h
.data
chr db 'F'
kx1 dw 40 ; col ;120
ky1 dw 10 ; row ;40
kx2 dw 400 ;130
ky2 dw 400 ;60
kx3 dw 40 ;90
ky3 dw 40 ;60
kx4 dw 40 ;140
ky4 dw 40 ;90
kx5 dw 40 ;40
ky5 dw 40 ;90
kx6 dw 40 ;150
ky6 dw 40 ;150
ky7 dw 40 ;10
kx7 dw 40 ;40
ky8 dw 40 ;40
kx8 dw 40 ;10

color db 5

.code
begin:
mov ax, @data
mov ds, ax
mov es, ax

mov ah, 0 ; 0 - ?????????? ??????????
mov al, 13h ; ?????????? = 13h (???????, 320?200)
int 10h ; ?????????? - ????? ??????.

mov cx, kx1 ; ????????????? ?????????? ?1 (?????? ????? ????????)
mov dx, ky1 ; ????????????? ?????????? Y1
mov ah, 0Ch ; ????? ??????? ????????? ?????
; CX - ?????? (Y) ; DX - ??????? (?)
xor bh, bh ; ????????????? - 0
mov al, color ; ????????????? ????

c1:
int 10h ; ???????? ?????????? ? ?????? ?????
cmp dx, ky2 ; ?????????? ?? ????????? y2
jne lp ; ???? ?? ????? - goto LP
cmp cx, kx2 ; ???? ????? - ?????????? ? ?2
jne lp2 ; ?? ????? - goto lp2
jmp ex ; ????? - ??????? ?? ????? (?.?. ???????? ?????????????? ?? ??????????)
lp:
inc dx ; ??????????? ??????????
jmp c1
lp2:
inc cx
jmp c1

ex:

; ??????????? ???? ?? ?????????? 2 ????? ??????????????
c2:
int 10h
cmp dx, ky1
jne lp3
cmp cx, kx1
jne lp4
jmp ex2
lp3:
dec dx
jmp c2
lp4:
dec cx
jmp c2
ex2:
mov cx, kx3
mov dx, ky3
mov ah, 0Ch
c3:
int 10h ; ???????? ?????????? ? ?????? ?????
cmp dx, ky4 ; ?????????? ?? ????????? y2
jne lp5 ; ???? ?? ????? - goto LP
cmp cx, kx4 ; ???? ????? - ?????????? ? ?2
jne lp6 ; ?? ????? - goto lp2
jmp ex3 ; ????? - ??????? ?? ????? (?.?. ???????? ?????????????? ?? ??????????)
lp5:
inc dx ; ??????????? ??????????
jmp c3
lp6:
inc cx
jmp c3

ex3:

; ??????????? ???? ?? ?????????? 2 ????? ??????????????
c4:
int 10h
cmp dx, ky3
jne lp7
cmp cx, kx3
jne lp8
jmp ex4
lp7:
dec dx
jmp c4
lp8:
dec cx
jmp c4
ex4:
mov cx, kx5
mov dx, ky5
mov ah, 0Ch
c5:
int 10h ; ???????? ?????????? ? ?????? ?????
cmp dx, ky6 ; ?????????? ?? ????????? y2
jne lp9 ; ???? ?? ????? - goto LP
cmp cx, kx6 ; ???? ????? - ?????????? ? ?2
jne lp10 ; ?? ????? - goto lp2
jmp ex5 ; ????? - ??????? ?? ????? (?.?. ???????? ?????????????? ?? ??????????)
lp9:
inc dx ; ??????????? ??????????
jmp c5
lp10:
inc cx
jmp c5

ex5:

; ??????????? ???? ?? ?????????? 2 ????? ??????????????
c6:
int 10h
cmp dx, ky5
jne lp11
cmp cx, kx5
jne lp12
jmp ex6
lp11:
dec dx
jmp c6
lp12:
dec cx
jmp c6
ex6:
mov cx, kx7
mov dx, ky7
mov ah, 0Ch
c7:
int 10h
cmp dx, ky8
jne lp13
jmp ex7
lp13:
dec dx
;inc cx
;jmp c7
ex7:

c8:
int 10h
;cmp dx, ky7
;jne lp14
jmp ex8
lp14:
inc dx
inc cx
jmp c8
ex8:
mov ah,1
int 21h
;mov ax,4c00h
end begin