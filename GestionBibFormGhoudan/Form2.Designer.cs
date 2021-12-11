
namespace GestionBibFormGhoudan
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.f1DataSet = new GestionBibFormGhoudan.f1DataSet();
            this.emprunteursBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emprunteursTableAdapter = new GestionBibFormGhoudan.f1DataSetTableAdapters.emprunteursTableAdapter();
            this.emprunteursBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.f1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emprunteursBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emprunteursBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // f1DataSet
            // 
            this.f1DataSet.DataSetName = "f1DataSet";
            this.f1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // emprunteursBindingSource
            // 
            this.emprunteursBindingSource.DataMember = "emprunteurs";
            this.emprunteursBindingSource.DataSource = this.f1DataSet;
            // 
            // emprunteursTableAdapter
            // 
            this.emprunteursTableAdapter.ClearBeforeFill = true;
            // 
            // emprunteursBindingSource1
            // 
            this.emprunteursBindingSource1.DataMember = "emprunteurs";
            this.emprunteursBindingSource1.DataSource = this.f1DataSet;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 736);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.f1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emprunteursBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emprunteursBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private f1DataSet f1DataSet;
        private System.Windows.Forms.BindingSource emprunteursBindingSource;
        private f1DataSetTableAdapters.emprunteursTableAdapter emprunteursTableAdapter;
        private System.Windows.Forms.BindingSource emprunteursBindingSource1;
    }
}