import React from "react";
import * as Server from "./server";
import { AsyncTypeahead } from "react-bootstrap-typeahead";
import "./HighSchoolTypeAhead.css";

// Use the onChange handler in the rendering component
// to access the name and id of the selected school:
//
// <HighSchoolTypeAhead onChange={this.onChange}/>
//
// state = {
//   selected: undefined
// };
//
// onChange = data => {
//   this.setState({ selected: data });
// };

class HighSchoolTypeAhead extends React.Component {
  state = {
    isLoading: false,
    SendingValue: "",
    schools: []
  };

  _handleSearch = query => {
    this.setState({ SendingValue: query }, () => this.sendToAjax());
  };

  sendToAjax = () => {
    this.setState({ isLoading: true });
    if (this.state.SendingValue.length) {
      const data = {};
      data.name = this.state.SendingValue;
      const myPromise = Server.highSchoolTypeAhead(data);
      myPromise.then(data => {
        if (data.data.items.length <= 50) {
          this.setState({ schools: data.data.items });
          this.setState({ isLoading: false });
        }
      });
    }
  };

  render() {
    return (
      <div className="HighSchoolTypeAhead">
        <AsyncTypeahead
          labelKey="name"
          minLength={3}
          isLoading={this.state.isLoading}
          onSearch={this._handleSearch}
          onChange={selected => {
            if (this.props.onChange) {
              this.props.onChange(selected);
            }
          }}
          placeholder="Search for a School..."
          options={this.state.schools}
        />
      </div>
    );
  }
}

export default HighSchoolTypeAhead;
