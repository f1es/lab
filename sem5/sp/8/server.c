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
    msgid = msgget(key, IPC_CREAT | 0666);
    printf("Сервер запущен. Ожидание сообщений...\n");
    while (1) {
        msgrcv(msgid, &msg, sizeof(msg.mtext), 1, 0);
        printf("Получено сообщение от клиента: %s\n", msg.mtext);
        printf("Введите сообщение: ");
        fgets(msg.mtext, sizeof(msg.mtext), stdin);
        msg.mtext[strcspn(msg.mtext, "\n")] = '\0';
        msg.mtype = 2;
        msgsnd(msgid, &msg, sizeof(msg.mtext), 0);
    }

    return 0;
}