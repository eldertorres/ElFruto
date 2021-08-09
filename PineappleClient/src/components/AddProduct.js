import React, { Component } from "react";
import withContext from "../withContext";
import { Redirect } from "react-router-dom";
import axios from 'axios';

const initState = {
  name: "",
  price: "",
  quantity: "",
  picture: "",
  pictureFile: "",
  description: ""
};

class AddProduct extends Component {
  constructor(props) {
    super(props);
    this.state = initState;
  }

  save = async (e) => {
    e.preventDefault();
    const { name, price, quantity, picture, description } = this.state;

    if (name && price) {      

      await axios.post(
        'https://localhost:5001/api/v1/Fruit/',
        { name, price, quantity, picture, description },
      )

      this.props.context.addProduct(
        {
          name,
          price,
          picture,
          description,
          quantity: quantity || 0
        },
        () => this.setState(initState)
      );
      this.setState(
        { flash: { status: 'is-success', msg: 'Fruta adicionada com sucesso' }}
      );

    } else {
      this.setState(
        { flash: { status: 'is-danger', msg: 'Os campos Nome e Preço são obrigatórios' }}
      );
    }
  };

  convertBase64 = (file) => {
    return new Promise((resolve, reject) => {
      const fileReader = new FileReader();
      fileReader.readAsDataURL(file)
      fileReader.onload = () => {
        resolve(fileReader.result);
      }
      fileReader.onerror = (error) => {
        reject(error);
      }
    })
  };

  handleFileRead = async (e) => {    
    const file = e.target.files[0]
    const base64 = await this.convertBase64(file)    
    this.setState({ picture: base64, error: "" })    
  };

  handleChange = e => this.setState({ [e.target.name]: e.target.value, error: "" });

  render() {
    const { name, price, quantity, pictureFile, description } = this.state;
    const { user } = this.props.context;

    return !(user && user.accessLevel < 1) ? (
      <Redirect to="/" />
    ) : (
      <>
        <div className="hero is-primary ">
          <div className="hero-body container">
            <h4 className="title">Adicionar Fruta</h4>
          </div>
        </div>
        <br />
        <br />
        <form onSubmit={this.save}>
          <div className="columns is-mobile is-centered">
            <div className="column is-one-third">
              <div className="field">
                <label className="label">Nome: </label>
                <input
                  className="input"
                  type="text"
                  name="name"
                  value={name}
                  onChange={this.handleChange}
                  required
                />
              </div>
              <div className="field">
                <label className="label">Preço: </label>
                <input
                  className="input"
                  type="number"
                  name="price"
                  value={price}
                  onChange={this.handleChange}
                  required
                />
              </div>
              <div className="field">
                <label className="label">Quantidade em estoque: </label>
                <input
                  className="input"
                  type="number"
                  name="quantity"
                  value={quantity}
                  onChange={this.handleChange}
                />
              </div>
              <div className="field">
                <label className="label">Imagem: </label>
                <input
                  className="input"
                  type="file"
                  name="pictureFile"
                  value={pictureFile}                  
                  onChange= {e => { this.handleChange(e); this.handleFileRead(e) }}
                />
              </div>
              <div className="field">
                <label className="label">Descrição: </label>
                <textarea
                  className="textarea"
                  type="text"
                  rows="2"
                  style={{ resize: "none" }}
                  name="description"
                  value={description}
                  onChange={this.handleChange}
                />
              </div>
              {this.state.flash && (
                <div className={`notification ${this.state.flash.status}`}>
                  {this.state.flash.msg}
                </div>
              )}
              <div className="field is-clearfix">
                <button
                  className="button is-primary is-outlined is-pulled-right"
                  type="submit"
                  onClick={this.save}
                >
                  Enviar
                </button>
              </div>
            </div>
          </div>
        </form>
      </>
    );
  }
}

export default withContext(AddProduct);
