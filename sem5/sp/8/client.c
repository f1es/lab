#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/types.h>
#include <sys/ipc.h>
#include <sys/msg.h>

#define MAX_TEXT_SIZE 128

struct message {
    long mtype;
    char mtext[MAX_TEXT_SIZE];
};

int main() {
    int msgid;
    key_t key;
    struct message msg;
    
    key = ftok(".", 'M');
    msgid = msgget(key, 0);
    printf("Клиент запущен\n");
    while (1) {
        printf("Введите сообщение: ");
        fgets(msg.mtext, sizeof(msg.mtext), stdin);
        msg.mtext[strcspn(msg.mtext, "\n")] = '\0';
        msg.mtype = 1;
        msgsnd(msgid, &msg, sizeof(msg.mtext), 0);
        msgrcv(msgid, &msg, sizeof(msg.mtext), 2, 0);
        printf("Получен ответ от сервера: %s\n", msg.mtext);
    }

    return 0;
}