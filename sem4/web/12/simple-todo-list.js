const todo = {
    action(e) {},
    add() {},
    create(text) {},
    init() {},
    update() {},
    save() {}
  };

  function init(){
    const fromStorage = localStorage.getItem('todo');
    if (fromStorage) {
      document.querySelector('.todo__items').innerHTML = fromStorage;
    }
    document.querySelector('.todo__options').addEventListener('change', this.update);
    document.addEventListener('click', this.action.bind(this));
  };

  function create(text) {
    return `<li class="todo__item" data-todo-state="active">
      <span class="todo__task">${text}</span>
      <span class="todo__action todo__action_restore" data-todo-action="active"></span>
      <span class="todo__action todo__action_complete" data-todo-action="completed"></span>
      <span class="todo__action todo__action_delete" data-todo-action="deleted"></span></li>`;
  };

  function save() {
    localStorage.setItem('todo', document.querySelector('.todo__items').innerHTML);
  }

  function update() {
    const option = document.querySelector('.todo__options').value;
    document.querySelector('.todo__items').dataset.todoOption = option;
    document.querySelector('.todo__text').disabled = option !== 'active';
  }

  function add() {
    const elemText = document.querySelector('.todo__text');
    if (elemText.disabled || !elemText.value.length) {
      return;
    }
    document.querySelector('.todo__items').insertAdjacentHTML('beforeend', this.create(elemText.value));
    elemText.value = '';
  }

  function action(e) {
    const target = e.target;
    if (target.classList.contains('todo__action')) {
      const action = target.dataset.todoAction;
      const elemItem = target.closest('.todo__item');
      if (action === 'deleted' && elemItem.dataset.todoState === 'deleted') {
        elemItem.remove();
      } else {
        elemItem.dataset.todoState = action;
      }
      this.save();
    } else if (target.classList.contains('todo__add')) {
      this.add();
      this.save();
    }
  }