import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink } from 'react-router-dom';
import { LivroData } from './CarregarLivro';

interface SalvarLivroDataState {
    title: string;
    loading: boolean;
    livroData: LivroData;
    showErro: boolean;
    erro: string;
}

export class SalvarLivro extends React.Component<RouteComponentProps<{}>, SalvarLivroDataState> {
    constructor(props) {
        super(props);

        this.state = { livroData: new LivroData, loading: true, title: "", showErro: false, erro: "" };

        var livroid = this.props.match.params["livroid"];

        // This will set state for Edit
        if (livroid > 0) {
            fetch('Livro/Detalhar/' + livroid, {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            })
                .then(response => response.json())
                .then(data => {
                    try {
                        this.setState({ livroData: JSON.parse(data), loading: false, showErro: false, title: "Editar Livro" });
                    }
                    catch (erro) {
                        throw data;
                    }
                })
                .catch(erro => {
                    this.setState({ loading: false, erro: erro, showErro: true });
                });
        }

        // This will set state for Add employee
        else {
            this.state = { title: "Criar Livro", loading: false, livroData: new LivroData, showErro: false, erro: "" };
        }

        // This binding is necessary to make "this" work in the callback
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Carregando...</em></p>
            : this.renderizarFormulario();

        return <div>
            <h1>{this.state.title}</h1>
            <hr />
            <div className="panel-body" style={{ display: this.state.showErro ? 'block' : 'none' }}>
                <h5 className="text-danger" id="panelErro">{this.state.erro}</h5>
            </div>
            {contents}
        </div>;
    }

    // This will handle the submit form event.
    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);

        // PUT request for Edit.
        if (this.state.livroData.id) {
            fetch('Livro/Editar', {
                method: 'PUT',
                body: data,
                headers: {
                    'Accept': 'application/json'
                }

            })
                .then(response => response.json())
                .then(data => {
                    if (data !== 'true') {
                        this.setState({ erro: data, showErro: true });
                    }
                    else {
                        this.props.history.push("/carregarlivro");
                    }
                });
        }

        // POST request for Add.
        else {
            fetch('Livro/Criar', {
                method: 'POST',
                body: data,
                headers: {
                    'Accept': 'application/json'
                }

            })
                .then(response => response.json())
                .then(data => {
                    if (data !== 'true') {
                        this.setState({ erro: data, showErro: true });
                    }
                    else {
                        this.props.history.push("/carregarlivro");
                    }
                });
        }
    }

    // This will handle Cancel button click event.
    private handleCancel(e) {
        e.preventDefault();
        this.props.history.push("/carregarlivro");
    }

    // Returns the HTML Form to the render() method.
    private renderizarFormulario() {
        return (
            <form onSubmit={this.handleSave} >
                <div className="form-group row" >
                    <input type="hidden" name="id" value={this.state.livroData.id} />
                </div>
                < div className="form-group row" >
                    <label className=" control-label col-md-1" htmlFor="Titulo">Título</label>
                    <div className="col-md-5">
                        <input className="form-control" type="text" name="titulo" defaultValue={this.state.livroData.titulo} required />
                    </div>
                    <label className=" control-label col-md-1" htmlFor="Autor">Autor</label>
                    <div className="col-md-5">
                        <input className="form-control" type="text" name="autor" defaultValue={this.state.livroData.autor} required />
                    </div>
                </div >
                < div className="form-group row" >
                    <label className=" control-label col-md-1" htmlFor="Genero">Gênero</label>
                    <div className="col-md-5">
                        <input className="form-control" type="text" name="genero" defaultValue={this.state.livroData.genero} />
                    </div>
                    <label className=" control-label col-md-1" htmlFor="Editora">Editora</label>
                    <div className="col-md-5">
                        <input className="form-control" type="text" name="editora" defaultValue={this.state.livroData.editora} />
                    </div>
                </div >
                < div className="form-group row" >
                    <label className=" control-label col-md-2" htmlFor="AnoEdicao">Ano de Edição</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" pattern="[0-9]*" name="anoEdicao" defaultValue={this.state.livroData.anoEdicao.toString()} />
                    </div>
                    <label className=" control-label col-md-2" htmlFor="QuantidadeExemplares">Quantitade de Exemplares</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" pattern="[0-9]*" name="quantidadeExemplares" defaultValue={this.state.livroData.quantidadeExemplares.toString()} required />
                    </div>
                </div >
                <div className="form-group">
                    <button type="submit" className="btn btn-success">Salvar</button>
                    <button className="btn btn-secondary" onClick={this.handleCancel}>Cancelar</button>
                </div >
            </form >
        )
    }
}