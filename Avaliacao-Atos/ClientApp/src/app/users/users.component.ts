import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../data-services/user.data-service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

    users: any[] = [];
    user: any = {};
    userLogin: any = {};
    userLogged: any = {};
    showList: boolean = true;
    isAutheticate: boolean = false;

    constructor(private userDataService: UserDataService) { }

    ngOnInit() {
        
    }

    get() {
        this.userDataService.get().subscribe((data : any[]) => {
            this.users = data;
            this.showList = true;
        }, error => {
            console.log(error);
            alert('erro interno');
        });
    }

    save() {
        if (this.user.id) {
            this.put();
        }
        else {
            this.post();
        }
    }

    openDetails(user) {
        this.showList = false;
        this.user = user;
    }

    delete(user) {
        this.userDataService.delete(user.id).subscribe(data => {
            if (data) {
                alert('Usuario removido com sucesso');
                this.get();
                this.user = {};
            }
            else {
                alert('Erro ao cadastrar usuario');
            }
        }, error => {
            console.log(error);
            alert('erro interno');
        });
    }

    post() {
        this.userDataService.post(this.user).subscribe(data => {
            if (data) {
                alert('Usuario cadastradado com sucesso');
                this.get();
            } else {
                alert('Erro ao cadastrar usuario');
            }
        }, error => {
            console.log(error);
            alert('erro interno');
        });
    }

    put() {
        this.userDataService.put(this.user).subscribe(data => {
            if (data) {
                alert('Usuario atualizado com sucesso');
                this.get();
            } else {
                alert('Erro ao atualizar usuario');
            }
        }, error => {
            console.log(error);
            alert('erro interno');
        });
    }

    authenticate() {
        this.userDataService.authenticate(this.userLogin).subscribe((data: any) => {

            if (data.user) {
                localStorage.setItem('user_logged', JSON.stringify(data));
                this.get();
                this.getUserData();
            }
            else {
                alert('Usuario inválido');
            }

        }, error => {
            console.log(error);
            alert('Usuario nao cadastrado');
        });
    }

    getUserData() {
        this.userLogged = JSON.parse(localStorage.getItem('user_logged'));
        this.isAutheticate = this.userLogged != null;
    }
}
